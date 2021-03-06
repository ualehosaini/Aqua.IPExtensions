﻿using System;
using System.Collections;
using System.Linq;
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

        /// <summary>
        /// To validate an IPv4 is 0000:0000:0000:0000:0000:0000:0000:0000
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPv6IsZero(this string ip)
        {
            return ip == "::" || ip == "0000:0000:0000:0000:0000:0000:0000:0000";
        }

        /// <summary>
        /// To validate an is a LinkLocal Ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsLinkLocalAddress(this string ip)
        {
            return ip.IsIPv4LinkLocalAddress() || ip.IsIPv6LinkLocalAddress();
        }

        /// <summary>
        /// To validate an IPv6 is a LocalHost IP (alternative for LoopBack)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsLocalHostv6(this string ip)
        {
            return ip.IsIPv6LoopBack();
        }

        /// <summary>
        /// To validate an IP is a LocalHost IP (alternative for LoopBack)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsLocalHost(this string ip)
        {
            return ip.IsLocalHostv4() || ip.IsLocalHostv6();
        }

        /// <summary>
        /// To validate an IP is 0.0.0.0 OR 0000:0000:0000:0000:0000:0000:0000:0000
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPisZero(this string ip)
        {
            return ip.IsIPv4IsZero() || ip.IsIPv6IsZero();
        }

        /// <summary>
        /// To validate an IPv6 Subnet Mask
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidSubnetIPv6Mask(this string mask)
        {
            string[] maskParts = mask.Split('/');

            if (maskParts.Length != 2)
            {
                return false;
            }

            if (!maskParts[0].IsValidIPv6())
            {
                return false;
            }

            if (int.Parse(maskParts[1]) < 0 || int.Parse(maskParts[1]) > 128)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// To validate an IP Subnet Mask (both IPv4 and IPv6)
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidSubnetMask(this string mask)
        {
            return mask.IsValidSubnetIPv4Mask() || mask.IsValidSubnetIPv6Mask();
        }

        /// <summary>
        /// Validate an IP address is belonging to a Subnet
        /// </summary>
        /// <param name="address"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static bool IsBelongsToSubnet(this IPAddress address, string mask)
        {
            if (!mask.IsValidSubnetMask())
            {
                return false;
            }

            string[] maskParts = mask.Split('/');

            var maskAddressPart = IPAddress.Parse(maskParts[0]);

            if (maskAddressPart.AddressFamily != address.AddressFamily) // IP version missmatch
            {
                return false;
            }

            int maskLength = int.Parse(maskParts[1]);

            if (maskAddressPart.AddressFamily == AddressFamily.InterNetwork)
            {
                var maskAddressBits = BitConverter.ToUInt32(maskAddressPart.GetAddressBytes().Reverse().ToArray(), 0);

                var ipAddressBits = BitConverter.ToUInt32(address.GetAddressBytes().Reverse().ToArray(), 0);

                uint m = uint.MaxValue << (32 - maskLength);

                return (maskAddressBits & m) == (ipAddressBits & m);
            }

            if (maskAddressPart.AddressFamily == AddressFamily.InterNetworkV6)
            {
                var maskAddressBits = new BitArray(maskAddressPart.GetAddressBytes());

                var ipAddressBits = new BitArray(address.GetAddressBytes());

                if (maskAddressBits.Length != ipAddressBits.Length)
                {
                    throw new ArgumentException("Missmatch in IP Address and Subnet Mask");
                }

                for (int maskIndex = 0; maskIndex < maskLength; maskIndex++)
                {
                    if (ipAddressBits[maskIndex] != maskAddressBits[maskIndex])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
