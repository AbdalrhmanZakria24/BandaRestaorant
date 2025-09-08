using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class CustomerRep
    {
        public CustomerRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();
        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
        public Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(c => c.Id == id);
        }
        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }
    }
}
