using System.ComponentModel.DataAnnotations;

namespace BandaRestaorant.Models
{
    public class Delivery : Order
    {
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        public Delivery() { }
        
    }
}
