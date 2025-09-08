using System.ComponentModel.DataAnnotations;

namespace BandaRestaorant.Models
{
    public abstract class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderTime { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public List<MenuOrder> MenuOrders { get; set; } = new List<MenuOrder>();
    }
}
