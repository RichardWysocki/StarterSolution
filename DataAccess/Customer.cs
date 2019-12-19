using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}