using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Landing.Cloacking.Models;
using Landing.Cloacking.BlackLists.Repository;

namespace Landing.Cloacking.BlackLists.Controllers
{
    public class BlackListController : Controller
    {

        private readonly BlackListRepository _repository;

        public BlackListController(BlackListRepository repository)
        {
            _repository = repository;
        }

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
        public async Task<IActionResult> Create([Bind("Address")] IP ip)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(ip);
                return RedirectToAction("Index");
            }
            return View(ip);
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
