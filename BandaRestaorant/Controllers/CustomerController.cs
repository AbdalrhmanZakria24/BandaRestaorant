using BandaRestaorant.Models;
using BandaRestaorant.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRep _customerRep = new CustomerRep();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(Customer customer)
        {
            if (customer.Name != null && customer.PhoneNumber != null)
            {
                _customerRep.Add(customer);
                return RedirectToAction("Create", "Mode");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _customerRep.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (customer.Name != null && customer.PhoneNumber != null)
            {
                _customerRep.Update(customer);
                return RedirectToAction("GetAll");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _customerRep.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _customerRep.GetById(id);
            if (item == null) return NotFound();

            _customerRep.Remove(item);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var list = _customerRep.GetAll();
            return View(list);
        }
    }
}
