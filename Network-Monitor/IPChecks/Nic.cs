using Network_Monitor.IP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.IPChecks
{
    class Nic //Defines a Nic Object
    {
        public static List<Nic> nics = new List<Nic>();

        UInt32 _ip;
        UInt32 _mask;
        public Nic(string ip, string mask)
        {
            _ip = ip.ParseIp();
            _mask = mask.ParseIp();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public UInt32 IP
        {
            get { return _ip; }
        }
        public UInt32 Mask
        {
            get { return _mask; }
        }

        public static void LoadNIC()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                var ipProps = adapter.GetIPProperties();

                foreach (var ip in ipProps.UnicastAddresses)
                {
                    if ((adapter.OperationalStatus == OperationalStatus.Up) && (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        Nic nic = new Nic(ip.Address.ToString(), ip.IPv4Mask.ToString());
                        nic.Name = adapter.Name;
                        nic.Description = adapter.Description;
                        nic.Type = adapter.NetworkInterfaceType.ToString();
                        nics.Add(nic);
                    }
                }
            }
        }
    }
}
