using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Landing.Cloacking.Models
{
    public class Campaign
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [DisplayName("White Landing Url")]
        public string WhiteLandingUrl { get; set; }
        [DisplayName("Black Landing Url")]
        public string BlackLandingUrl { get; set; }
        [DisplayName("Cloaking Url")]
        public string CloackingUrl { get; set; }
        public List<IPEntry> LoggedIPs { get; set; } = new List<IPEntry>();

        public class IPEntry
        {
            public string Address { get; set; }
            public DateTime LoggedAt { get; set; } = DateTime.Now;
        }
    }
}
