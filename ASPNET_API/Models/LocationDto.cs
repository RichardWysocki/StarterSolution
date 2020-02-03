namespace ASPNET_API.Models
{
    public class LocationDto
    {
        public int CustomerLocationId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}