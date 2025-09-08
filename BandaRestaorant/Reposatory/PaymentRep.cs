using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class PaymentRep
    {
        public PaymentRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();
        public void Add(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }
        public void Update(Payment payment)
        {
            context.Payments.Update(payment);
            context.SaveChanges();
        }
        public void Remove(Payment payment)
        {
            context.Payments.Remove(payment);
            context.SaveChanges();
        }
        public Payment GetById(int id)
        {
            return context.Payments.FirstOrDefault(p => p.Id == id);
        }
        public List<Payment> GetAll()
        {
            return context.Payments.ToList();
        }
    }
}
