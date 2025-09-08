using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class InRestorantRep
    {
        public InRestorantRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();
        public void Add(InRestaorant inRestaorant)
        {
            context.InRestaorants.Add(inRestaorant);
            context.SaveChanges();
        }
        public void Remove(InRestaorant inRestaorant)
        {
            context.InRestaorants.Remove(inRestaorant);
            context.SaveChanges();
        }
        public void Update(InRestaorant inRestaorant)
        {
            context.InRestaorants.Update(inRestaorant);
            context.SaveChanges();
        }
        public List<InRestaorant> GetAll()
        {
            return context.InRestaorants.ToList();
        }
        public List<Menu> GetAllMenus()
        {
            return context.Menus.ToList();
        }
        public IEnumerable<Menu> GetMenusByIds(List<int> ids)
        {
            return context.Menus.Where(m => ids.Contains(m.Id)).ToList();
        }
        public void AddOrderWithMenus(InRestaorant order, List<Menu> menus)
        {
            foreach (var menu in menus)
            {

                order.MenuOrders.Add(new MenuOrder
                {
                    MenuId = menu.Id,

                    Order = order
                });
            }

            context.InRestaorants.Add(order);
            context.SaveChanges();
        }
    }
}
