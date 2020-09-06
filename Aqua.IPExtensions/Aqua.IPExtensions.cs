using System.Net;
using System.Net.Sockets;

namespace Aqua.IPExtensions
{
    public static class IPExtensions
    {
        /// <summary>
        /// To validate an IPv4 string
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIPv4(this string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return false;
            }

            IPAddress ipTemp;
            if (IPAddress.TryParse(ip, out ipTemp))
            {
                return ipTemp.AddressFamily == AddressFamily.InterNetwork;
            }

            return false;
        }

        /// <summary>
        /// To validate an IPv4 is a LinkLocal Ip (169.254.x.x)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPv4LinkLocalAddress(this string ip)
        {
            return ip.IsValidIPv4() && ip.Substring(0, 7) == "169.254";
        }

        /// <summary>
        /// To validate an IPv4 is a LoopBack IP (127.0.0.1)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPv4LoopBack(this string ip)
        {
            return ip == "127.0.0.1";
        }

        /// <summary>
        /// To validate an IPv4 is a LocalHost IP (alternative for LoopBack)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsLocalHostv4(this string ip)
        {
            return ip.IsIPv4LoopBack();
        }

        /// <summary>
        /// To validate an IPv4 is 0.0.0.0
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPv4IsZero(this string ip)
        {
            return ip == "0.0.0.0";
        }

        /// <summary>
        /// To validate an IPv4 Subnet Mask
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidSubnetIPv4Mask(this string mask)
        {
            if (string.IsNullOrWhiteSpace(mask))
                return false;

            string[] maskParts = mask.Split('/');

            if (maskParts.Length != 2)
            {
                return false;
            }

            if (!maskParts[0].IsValidIPv4())
            {
                return false;
            }

            if (int.Parse(maskParts[1]) < 0 || int.Parse(maskParts[1]) > 32)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// To validate an IPv6 string
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIPv6(this string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return false;
            }

            IPAddress ipTemp;
            if (IPAddress.TryParse(ip, out ipTemp))
            {
                return ipTemp.AddressFamily == AddressFamily.InterNetworkV6;
            }

            return false;

        }

        /// <summary>
        /// To validate an IPv6 is a LinkLocal Ip (fe80:: to febf:ffff:ffff:ffff:ffff:ffff:ffff:ffff)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPv6LinkLocalAddress(this string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return false;
            }

            if (ip.Length >= 4 && ip.IsValidIPv6())
            {
                int intTemp;
                if (int.TryParse(ip.Substring(0, 4), System.Globalization.NumberStyles.HexNumber, null, out intTemp))
                {
                    // reference: https://en.wikipedia.org/wiki/Reserved_IP_addresses#IPv6

                    return intTemp >= int.Parse("fe80", System.Globalization.NumberStyles.HexNumber)
                        && intTemp <= int.Parse("febf", System.Globalization.NumberStyles.HexNumber);
                }
            }

            return false;
        }

        /// <summary>
        /// To validate an IPv6 is a LoopBack IP (::1)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPv6LoopBack(this string ip)
        {
            return ip == "::1";
        }

        /// <summary>
        /// To validate an IPv4 or IPv6 string
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIPv4Orv6(this string ip)
        {
            return ip.IsValidIPv4() || ip.IsValidIPv6();
        }

        /// <summary>
        /// To validate an IPv4 or IPv6 is a LoopBack IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsLoopBack(this string ip)
        {
            return ip.IsIPv4LoopBack() || ip.IsIPv6LoopBack();
        }

    }
}
