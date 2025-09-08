using BandaRestaorant.Context;
using BandaRestaorant.Models;

namespace BandaRestaorant.Reposatory
{
    public class TakeawayRep
    {
        public TakeawayRep() { }
        private readonly ApplicationDBContext context = new ApplicationDBContext();
        public void Add(TakeAway takeAway)
        {
            context.TakeAways.Add(takeAway);
            context.SaveChanges();
        }
        public void Remove(TakeAway takeAway)
        {
            context.TakeAways.Remove(takeAway);
            context.SaveChanges();
        }
        public void Update(TakeAway takeAway)
        {
            context.TakeAways.Update(takeAway);
            context.SaveChanges();
        }
        public List<TakeAway> GetAll()
        {
            return context.TakeAways.ToList();
        }
        public List<Menu> GetAllMenus()
        {
            return context.Menus.ToList();
        }
        public IEnumerable<Menu> GetMenusByIds(List<int> ids)
        {
            return context.Menus.Where(m => ids.Contains(m.Id)).ToList();
        }
    }
}
