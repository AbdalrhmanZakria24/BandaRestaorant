using System.ComponentModel.DataAnnotations;

namespace BandaRestaorant.Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}
