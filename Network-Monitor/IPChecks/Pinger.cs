using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace Network_Monitor.IPChecks
{
    class Pinger
    {
    public static PingReply PingIP(string IP, int timeout)
        {
            try
            {
                Ping ping = new Ping();
                string pingMessage = "NetworkMonitorPingCheck";
                byte[] buffer = Encoding.ASCII.GetBytes(pingMessage);

                PingReply reply = ping.Send(IP, timeout, buffer);
                return reply;
            }
            catch
            {
                return null;
            }
        }
    }
}
