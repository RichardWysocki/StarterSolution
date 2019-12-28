using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_WebApplication.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string State { get; set; }
    }
}
