using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class DeliveryRep
    {
        public DeliveryRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();
        public void Add(Delivery deliver)
        {
            context.Deliveries.Add(deliver);
            context.SaveChanges();
        }
        public void Remove(Delivery deliver)
        {
            context.Deliveries.Remove(deliver);
            context.SaveChanges();
        }
        public void Update(Delivery deliver)
        {
            context.Deliveries.Update(deliver);
            context.SaveChanges();
        }
        public List<Delivery> GetAll()
        {
            return context.Deliveries.ToList();
        }
        public List<Menu> GetAllMenus()
        {
            return context.Menus.ToList();
        }
        public IEnumerable<Menu> GetMenusByIds(List<int> ids)
        {
            return context.Menus.Where(m => ids.Contains(m.Id)).ToList();
        }
        public void AddOrderWithMenus(Delivery order, List<Menu> menus)
        {
            foreach (var menu in menus)
            {

                order.MenuOrders.Add(new MenuOrder
                {
                    MenuId = menu.Id,

                    Order = order
                });
            }

            context.Deliveries.Add(order);
            context.SaveChanges();
        }
    }
}
