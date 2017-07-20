using System;
using System.Collections.Generic;

namespace Landing.Cloacking.Models
{
    public class Campaign
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string WhiteLandingUrl { get; set; }
        public string BlackLandingUrl { get; set; }
        public string CloackingUrl { get; set; }
        public List<IPEntry> LoggedIPs { get; set; } = new List<IPEntry>();

        public class IPEntry
        {
            public string Address { get; set; }
            public DateTime LoggedAt { get; set; } = DateTime.Now;
        }
    }
}
