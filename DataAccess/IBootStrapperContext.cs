using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public  interface IBootStrapperContext
    {
        void SaveChanges();

        DbSet<Customer> Customers { get; set; }
    }
}