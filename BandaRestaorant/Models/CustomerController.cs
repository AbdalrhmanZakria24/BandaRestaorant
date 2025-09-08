using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Models
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
