namespace BandaRestaorant.Models
{
    public class MenuOrder
    {
        public MenuOrder() { }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public Order Order { get; set; }
    }
}
