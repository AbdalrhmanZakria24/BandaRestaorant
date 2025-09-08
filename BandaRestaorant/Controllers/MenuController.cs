using BandaRestaorant.Models;
using BandaRestaorant.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace BandaRestaorant.Controllers
{
    public class MenuController : Controller
    {
        MenuRep _menuRep = new MenuRep();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            if (menu.Name != null)
            {
                _menuRep.Add(menu);
                return RedirectToAction("GetAll");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _menuRep.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Menu menu)
        {
            if (menu.Name != null)
            {
                _menuRep.Update(menu);

                return RedirectToAction("GetAll");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _menuRep.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteFormating(int id)
        {
            var item = _menuRep.GetById(id);
            if (item == null) return NotFound();

            _menuRep.Remove(item);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var item = _menuRep.GetAll();
            return View(item);
        }
    }
}
