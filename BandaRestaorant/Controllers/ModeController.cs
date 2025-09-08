using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class ModeController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
