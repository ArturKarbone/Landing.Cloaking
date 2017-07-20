using Landing.Cloacking.Models;
using Landing.Cloaking.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landing.Cloacking.Campaigns
{
    public class CampaignRepository : FirebaseRepository
    {
        public Campaign Get(string id)
        {
            return Client.GetSync<Campaign>($"campaigns/{id}");
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Campaign> All()
        {
            var campaigns = Client.GetSync<Dictionary<string, Campaign>>("campaigns");
            return campaigns?.Values?.ToList() ?? new List<Campaign>();
        }

        public void Save(Campaign campaign)
        {
            Client.SetSync($"campaigns/{campaign.Id}", campaign);
        }
    }
}
