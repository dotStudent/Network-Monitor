using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.IPChecks
{
    public static class Hostname
    {
        public static string Get(string ipAddress) //Resolve Hostname
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch
            {
                //unknown host or  //not every IP has a name  //log exception (manage it)
            }
            return "";
        }
    }
}
