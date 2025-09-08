using BandaRestaorant.Models;

namespace BandaRestaorant.ViewModel
{
    public class OrderSummaryViewModel
    {
        public List<Menu> SelectedMenus { get; set; }
        public double TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
