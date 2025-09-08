using System.ComponentModel.DataAnnotations;

namespace BandaRestaorant.Models
{
    public class Payment
    {
        public Payment()
        {
        }
        [Key]
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
