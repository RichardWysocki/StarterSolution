using System.Collections.Generic;

namespace ASPNET_API.Models
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string State { get; set; }

        public List<LocationDTO> Location { get; set; }
    }

    public class LocationDTO
    {
        public int CustomerLocationId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
