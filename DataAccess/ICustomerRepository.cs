using System.Collections.Generic;

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
