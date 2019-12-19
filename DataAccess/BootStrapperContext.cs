using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataAccess
{
    class BootStrapperContext : DbContext
    {
        public BootStrapperContext(DbContextOptions<BootStrapperContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        
    }
}
