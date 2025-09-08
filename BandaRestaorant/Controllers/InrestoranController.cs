using BandaRestaorant.Models;
using BandaRestaorant.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class InrestoranController : Controller
    {
        InRestorantRep _InRestorantRep = new InRestorantRep();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Print()
        {
            var menus = _InRestorantRep.GetAllMenus();
            return View(menus);
        }
        [HttpPost]
        public IActionResult Print(Order order)
        {
            if (order == null || order.MenuOrders == null || order.MenuOrders.Count == 0)
            {
                ViewBag.Message = "No items in the menu yet.";
                return View(new List<Menu>());
            }

            return View(order.MenuOrders);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                ViewBag.Message = "No items were selected.";
                return RedirectToAction("Print");
            }


            var menus = _InRestorantRep.GetMenusByIds(selectedIds).ToList();


            ViewBag.TotalPrice = menus.Sum(m => m.Price);

            return View("OrderSummary", menus);
        }
        [HttpGet]
        public IActionResult ConfirmOrder()
        {
            return View("ThankYou");
        }

        [HttpPost]
        public IActionResult ConfirmOrder([FromForm] List<int> selectedMenuIds, int customerId)
        {
            if (selectedMenuIds == null || !selectedMenuIds.Any())
            {
                TempData["Message"] = "You must select at least one item!";
                return RedirectToAction("Print");
            }

            var menus = _InRestorantRep.GetMenusByIds(selectedMenuIds).ToList();

            var order = new InRestaorant
            {
                CustomerId = customerId,
                TotalPrice = menus.Sum(m => m.Price),
                OrderDate = DateTime.Now,
                OrderTime = DateTime.Now,
                MenuOrders = new List<MenuOrder>()
            };

            _InRestorantRep.AddOrderWithMenus(order, menus);

            TempData["Message"] = "Thank you for your order!";
            return View("ThankYou", order);

        }

    }
}
