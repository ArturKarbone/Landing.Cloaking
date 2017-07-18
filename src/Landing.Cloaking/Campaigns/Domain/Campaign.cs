using System;

namespace Landing.Cloacking.Models
{
    public class Campaign
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string WhiteLandingUrl { get; set; }
        public string BlackLandingUrl { get; set; }
        public string CloackingUrl { get; set; }
    }
}
