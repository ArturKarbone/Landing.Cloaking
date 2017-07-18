using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Landing.Cloacking.Models;
using Landing.Cloacking.Campaigns;

namespace Landing.Cloacking.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly CampaignRepository _repository;

        public CampaignsController(CampaignRepository repository)
        {
            _repository = repository;
        }

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            return View(_repository.All());
        }


        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = _repository.Get(id);

            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WhiteLandingUrl,BlackLandingUrl,CloackingUrl")] Campaign campaign)
        {
            campaign.CloackingUrl = $"http://{this.Request.Host}/campaigns/handle/{campaign.Id}";

            if (ModelState.IsValid)
            {
                _repository.Save(campaign);
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = _repository.Get(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,WhiteLandingUrl,BlackLandingUrl,CloackingUrl")] Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Save(campaign);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.Exists(campaign.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = _repository.Get(id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
