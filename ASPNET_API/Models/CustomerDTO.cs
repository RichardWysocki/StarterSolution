using System.Collections.Generic;

namespace ASPNET_API.Models
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string State { get; set; }

        public List<LocationDto> Location { get; set; }
    }
}
