using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface ICustomerRepository
    {
            List<Customer> GetAllCustomers();

            Customer GetCustomerByCustomerID(int Id);

            Customer CreateCustomer(Customer customer);
            bool UpdateCustomer(Customer customer);

            void DeleteCustomer(int id);
        
    }
}
