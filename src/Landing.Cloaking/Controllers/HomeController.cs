using Landing.Cloacking.Cloaking;
using Microsoft.AspNetCore.Mvc;

namespace Landing.Cloacking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
