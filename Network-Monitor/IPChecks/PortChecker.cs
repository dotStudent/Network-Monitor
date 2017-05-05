using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.IPChecks
{
    class PortChecker
    {
       public static bool? ScanPort(IPAddress ip, int port)
        {
            try
            {
                System.Net.Sockets.Socket sock =
                    new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork,
                                                  System.Net.Sockets.SocketType.Stream,
                                                  System.Net.Sockets.ProtocolType.Tcp);
                sock.Connect(ip, port);
                if (sock.Connected == true) // Port is in use and connection is successful
                {
                    return true;
                }
                sock.Close();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                if (ex.ErrorCode == 10061) // Port is unused and could not establish connection 
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            return null;
        }
    }
}
