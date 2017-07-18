using Landing.Cloacking.Models;
using System.Collections.Generic;
using System.Linq;

namespace Landing.Cloacking.BlackLists.Repository
{
    public class BlackListRepository
    {
        public static List<IP> Addresses { get; set; } = new List<IP> {
            new IP("::1")
        };

        public IP Get(string ip)
        {
            return Addresses.First(x => x.Address == ip);
        }

        public void Delete(string ip)
        {
            Addresses.Remove(Addresses.First(x => x.Address == ip));
        }

        public List<IP> All()
        {
            return Addresses.ToList();
        }

        public void Save(IP address)
        {
            Addresses.Add(address);
        }
    }
}
