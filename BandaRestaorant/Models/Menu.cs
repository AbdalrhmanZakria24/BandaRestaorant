using System.ComponentModel.DataAnnotations;

namespace BandaRestaorant.Models
{
    public enum MenuCatogre
    {
        Appitiar = 1,
        MineDish = 2,
        Dessert = 3,
        Beverage = 4
    }
    public class Menu
    {
        public Menu() { }
        public Menu(string name, double price, MenuCatogre catogre)
        {
            Name = name;
            Price = price;
            Catogre = catogre;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public MenuCatogre Catogre { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<MenuOrder> MenuOrders { get; set; }
    }
}
