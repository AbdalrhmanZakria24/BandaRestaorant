using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class MenuOrderRep
    {
        public MenuOrderRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();
        public void Add(MenuOrder menuOrder)
        {
            context.MenuOrders.Add(menuOrder);
            context.SaveChanges();
        }
        public void Remove(MenuOrder menuOrder)
        {
            context.MenuOrders.Remove(menuOrder);
            context.SaveChanges();
        }
        public MenuOrder GetById(int Menuid, int Orderid)
        {
            return context.MenuOrders.FirstOrDefault(mo => mo.MenuId == Menuid && mo.OrderId == Orderid);
        }
        public void Update(MenuOrder menuOrder)
        {
            context.MenuOrders.Update(menuOrder);
            context.SaveChanges();
        }
        public List<MenuOrder> GetAll()
        {
            return context.MenuOrders.ToList();
        }
    }
}
