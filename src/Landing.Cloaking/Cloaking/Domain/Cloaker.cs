using Landing.Cloacking.Campaigns;
using Landing.Cloacking.Models;
using System;
using System.Net;

namespace Landing.Cloacking.Cloaking
{
    public class Cloaker
    {
        #region Dependencies

        readonly CampaignRepository _repository;
        readonly BlackList _blackList;

        public Cloaker(CampaignRepository repository, BlackList blackList)
        {
            _repository = repository;
            _blackList = blackList;
        }

        #endregion

        public CloakingResponse Handle(CloakingRequest request)
        {
            var campaign = _repository.Get(request.CampaignId);
            Uri landing;

            if (_blackList.Contains(new IP(request.IP.ToString())))
            {
                landing = new Uri(campaign.BlackLandingUrl);
            }
            else
            {
                landing = new Uri(campaign.WhiteLandingUrl);
            }

            return new CloakingResponse
            {
                Landing = landing
            };
        }
    }

    public class CloakingRequest
    {
        public string CampaignId { get; set; }
        public IPAddress IP { get; set; }
    }

    public class CloakingResponse
    {
        public Uri Landing { get; set; }
    }
}
