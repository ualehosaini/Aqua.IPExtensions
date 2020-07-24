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
    }
}
