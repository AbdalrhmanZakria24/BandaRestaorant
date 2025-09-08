using System.ComponentModel.DataAnnotations;

namespace BandaRestaorant.Models
{
    public class InRestaorant : Order
    {
        [Required]
        public int TableNumber { get; set; }
        public InRestaorant() { }
    }
}
