using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;

namespace Landing.Cloacking.Models
{
    public class IP
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public IP(string address)
        {
            this.Address = address;
        }

        public IP()
        {

        }
        public string Address { get; set; }
    }

    public class BlackList
    {
        protected List<IP> BlakckListedIPs = new List<IP>()
        {
            new IP("::1")
        };

        public bool Contains(IP address)
        {
            return BlakckListedIPs.Any(x => x.Equals(address));
        }
    }
}