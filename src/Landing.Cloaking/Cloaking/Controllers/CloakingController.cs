using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landing.Cloacking.Cloaking.Controllers
{

    public class CloakingController : Controller
    {
        readonly Cloaker _cloacker;

        public CloakingController(Cloaker cloacker)
        {
            _cloacker = cloacker;
        }

        public IActionResult Handle(string id)
        {
            var ip = this.Request.HttpContext.Connection.RemoteIpAddress;

            var result = _cloacker.Handle(new CloakingRequest { CampaignId = id, IP = ip });

            return Redirect(result.Landing.ToString());
        }
    }
}
