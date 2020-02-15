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
    }
}
