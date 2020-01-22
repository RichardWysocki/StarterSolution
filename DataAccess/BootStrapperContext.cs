using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataAccess
{
    public class BootStrapperContext : DbContext, IBootStrapperContext
    {
        public BootStrapperContext()
        {
        }

        public BootStrapperContext(DbContextOptions<BootStrapperContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        void IBootStrapperContext.SaveChanges()
        {
            base.SaveChanges();
        }

    }
}
