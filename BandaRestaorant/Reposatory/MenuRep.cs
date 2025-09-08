using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class MenuRep
    {
        public MenuRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();

        public void Add(Menu menu)
        {
            context.Menus.Add(menu);
            context.SaveChanges();
        }
        public void Remove(Menu menu)
        {
            context.Menus.Remove(menu);
            context.SaveChanges();
        }
        public Menu GetById(int id)
        {
            return context.Menus.FirstOrDefault(m => m.Id == id);
        }
        public void Update(Menu menu)
        {
            context.Menus.Update(menu);
            context.SaveChanges();
        }
        public List<Menu> GetAll()
        {
            return context.Menus.ToList();
        }
    }
}
