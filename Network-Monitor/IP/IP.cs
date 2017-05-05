using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.IP
{
    public class IP
    {//Class for IP List
        public IP(System.Net.IPAddress _ip)
        {
            ip = _ip;
        }
        public System.Net.IPAddress ip { get; set; } = null;
        public DateTime? Last_Checked { get; set; } = null;
        public bool? RunningCheck { get; set; } = null;
    }

}
