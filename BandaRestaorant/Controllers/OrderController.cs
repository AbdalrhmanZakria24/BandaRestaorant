using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Details(int type)
        {
            switch (type)
            {
                case 1:
                    return RedirectToAction("Print", "Inrestoran");
                case 2:
                    return RedirectToAction("Print", "Delivary");
                case 3:
                    return RedirectToAction("Print", "TakeAway");
                default:
                    return NotFound();
            }
        }
    }
}
