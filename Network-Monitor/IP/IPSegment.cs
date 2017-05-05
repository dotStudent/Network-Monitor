using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Monitor.IP
{
    class IPSegment
    {

        private UInt32 _ip;
        private UInt32 _mask;

        public IPSegment(string ip, string mask)
        {
            _ip = ip.ParseIp();
            _mask = mask.ParseIp();
        }

        public UInt32 NumberOfHosts
        {
            get { return ~_mask + 1; }
        }

        public UInt32 NetworkAddress
        {
            get { return _ip & _mask; }
        }

        public UInt32 BroadcastAddress
        {
            get { return NetworkAddress + ~_mask; }
        }
        public UInt32 FirstIP
        {
            get { return NetworkAddress + 1; }
        }
        public UInt32 LastIP
        {
            get { return BroadcastAddress - 1; }
        }
        public IEnumerable<UInt32> Hosts()
        {
            for (var host = NetworkAddress + 1; host < BroadcastAddress; host++)
            {
                    yield return host;
            }
        }
        public bool isInNetwork(string ip)
        {
            if (ip.ParseIp() > NetworkAddress && ip.ParseIp() < BroadcastAddress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
