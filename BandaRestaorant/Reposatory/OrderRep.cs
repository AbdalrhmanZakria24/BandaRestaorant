using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class OrderRep
    {
        public OrderRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();

        public void Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
        public void Remove(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }
        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(o => o.Id == id);
        }
        public void Update(Order order)
        {

            context.Orders.Update(order);
            context.SaveChanges();
        }
        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }
    }
}
