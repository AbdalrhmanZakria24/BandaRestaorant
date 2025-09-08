namespace BandaRestaorant.Models
{
    public class TakeAway : Order
    {
        public DateTime PickupTime { get; set; }  
        public TakeAway() { }
    }
}
