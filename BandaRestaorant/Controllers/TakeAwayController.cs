using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class TakeAwayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
