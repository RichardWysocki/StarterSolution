namespace DataAccess
{
    public class CustomerLocation
    {
        public int CustomerLocationId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
