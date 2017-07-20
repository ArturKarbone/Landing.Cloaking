using Landing.Cloacking.Models;
using Landing.Cloaking.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landing.Cloacking.BlackLists.Repository
{

    public class BlackListRepository : FirebaseRepository
    {
        public IP Get(string id)
        {
            return Client.GetSync<IP>($"blacklist/{id}");
        }

        public bool Contains(IP ip)
        {
            return All().Any(x => x.Address == ip.Address);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<IP> All()
        {
            var campaigns = Client.GetSync<Dictionary<string, IP>>("blacklist");
            return campaigns?.Values?.ToList() ?? new List<IP>();
        }

        public void Save(IP ip)
        {
            Client.SetSync($"blacklist/{ip.Id}", ip);
        }
    }    
}
