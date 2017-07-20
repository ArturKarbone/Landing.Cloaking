using Landing.Cloacking.BlackLists.Repository;
using Landing.Cloacking.Campaigns;
using Landing.Cloacking.Models;
using System;
using System.Net;
using static Landing.Cloacking.Models.Campaign;

namespace Landing.Cloacking.Cloaking
{
    public class Cloaker
    {
        #region Dependencies

        readonly CampaignRepository _repository;
        readonly BlackListRepository _blackListRepository;

        public Cloaker(CampaignRepository repository, BlackListRepository blackListRepository)
        {
            _repository = repository;
            _blackListRepository = blackListRepository;
        }

        #endregion

        public CloakingResponse Handle(CloakingRequest request)
        {
            var campaign = _repository.Get(request.CampaignId);
            Uri landing;

            campaign.LoggedIPs.Add(new IPEntry { Address = request.IP.ToString() });
            _repository.Save(campaign);

            if (_blackListRepository.Contains(new IP(request.IP.ToString())))
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
