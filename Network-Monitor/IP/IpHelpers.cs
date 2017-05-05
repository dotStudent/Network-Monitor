using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.IP
{
    public static class IpHelpers
    {
        public static string ToIpString(this UInt32 value)
        {
            var bitmask = 0xff000000;
            var parts = new string[4];
            for (var i = 0; i < 4; i++)
            {
                var masked = (value & bitmask) >> ((3 - i) * 8);
                bitmask >>= 8;
                parts[i] = masked.ToString(CultureInfo.InvariantCulture);
            }
            return String.Join(".", parts);
        }
        public static System.Net.IPAddress ToIpAddress(this UInt32 value)
        {
            var bitmask = 0xff000000;
            var parts = new string[4];
            for (var i = 0; i < 4; i++)
            {
                var masked = (value & bitmask) >> ((3 - i) * 8);
                bitmask >>= 8;
                parts[i] = masked.ToString(CultureInfo.InvariantCulture);
            }
            return System.Net.IPAddress.Parse(String.Join(".", parts));
        }
        public static UInt32 ParseIp(this string ipAddress)
        {
            try
            {
                var splitted = ipAddress.Split('.');
                UInt32 ip = 0;
                for (var i = 0; i < 4; i++)
                {
                    ip = (ip << 8) + UInt32.Parse(splitted[i]);
                }
                return ip;
            }
            catch (System.IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public static bool isValidIP(string ip)
        {
            System.Net.IPAddress ipAddress = null;
            bool isIp = System.Net.IPAddress.TryParse(ip, out ipAddress);
            return isIp;
        }
        public static bool IsValidPort(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            if (isNum == true)
            {
                int uncheckedPort = Convert.ToInt32(Expression);

                if (uncheckedPort >= 1 && uncheckedPort <= 65535)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
