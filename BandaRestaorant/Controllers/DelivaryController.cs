using BandaRestaorant.Models;
using BandaRestaorant.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class DelivaryController : Controller
    {
        DeliveryRep _DeliveryRep { get; set; } = new DeliveryRep();
        private readonly CustomerRep _CustomerRep = new CustomerRep();
        [HttpGet]
        public IActionResult Print()
        {
            var menu = _DeliveryRep.GetAllMenus();
            return View(menu);
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
        [HttpPost]
        public IActionResult Addadresse(List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                TempData["Message"] = "You must select at least one item!";
                return RedirectToAction("Print");
            }


            var customer = _CustomerRep.GetAll().FirstOrDefault();
            if (customer == null)
            {
                TempData["Message"] = "No customer found!";
                return RedirectToAction("Print");
            }

            ViewBag.CustomerId = customer.Id; 
            return View(selectedIds);
        }

        [HttpPost]
        public IActionResult ConfirmDelivery([FromForm] List<int> selectedMenuIds, int customerId, string address)
        {
            if (selectedMenuIds == null || !selectedMenuIds.Any())
            {
                TempData["Message"] = "You must select at least one item!";
                return RedirectToAction("Print");
            }

            var menus = _DeliveryRep.GetMenusByIds(selectedMenuIds).ToList();

            var order = new Delivery
            {
                CustomerId = customerId,
                TotalPrice = menus.Sum(m => m.Price),
                OrderDate = DateTime.Now,
                OrderTime = DateTime.Now,
                Address = address,
                MenuOrders = new List<MenuOrder>()
            };

            _DeliveryRep.AddOrderWithMenus(order, menus);

            TempData["Message"] = "Thank you! Your delivery is confirmed.";
            return View("ThankYou", order);
        }

        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();
        }


    }
}
