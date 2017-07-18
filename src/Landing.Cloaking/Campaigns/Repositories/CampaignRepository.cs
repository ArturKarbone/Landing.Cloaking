using Landing.Cloacking.Models;
using System.Collections.Generic;
using System.Linq;

namespace Landing.Cloacking.Campaigns
{

    public class CampaignRepository
    {
        public static List<Campaign> Campaigns { get; set; } = new List<Campaign> {
            new Campaign
            {
                 Id = "test",
                 BlackLandingUrl = "b1",
                 CloackingUrl = "c1",
                 WhiteLandingUrl = "w1"

            },
            new Campaign
            {
                 BlackLandingUrl = "b2",
                 CloackingUrl = "c2",
                 WhiteLandingUrl = "w2"
            }
        };


        public Campaign Get(string id)
        {
            return Campaigns.First(x => x.Id == id);
        }

        public bool Exists(string id)
        {
            return Campaigns.Any(x => x.Id == id);
        }

        public void Delete(string id)
        {
            Campaigns.Remove(Campaigns.First(x => x.Id == id));
        }


        public List<Campaign> All()
        {
            return Campaigns.ToList();
        }

        public void Save(Campaign campaign)
        {
            var existingCampaign = Campaigns.FirstOrDefault(x => x.Id == campaign.Id);

            if (null != existingCampaign)
            {
                existingCampaign = campaign;
            }
            else
            {
                Campaigns.Add(campaign);
            }
        }
    }
}
