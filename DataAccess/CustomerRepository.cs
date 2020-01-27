using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;

namespace DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IBootStrapperContext _bootStrapperContext;

        public CustomerRepository(IBootStrapperContext bootStrapperContext)
        {
            _bootStrapperContext = bootStrapperContext;
        }


        public List<Customer> GetAllCustomers()
        {
            return _bootStrapperContext.Customers.ToList();
        }

        public Customer CreateCustomer(Customer customer)
        {
            _bootStrapperContext.Customers.Add(customer);
            _bootStrapperContext.SaveChanges();
            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var result = _bootStrapperContext.Customers.SingleOrDefault(b => b.CustomerId == customer.CustomerId);
            if (result != null)
            {
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
                _bootStrapperContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerByCustomerID(id);
            _bootStrapperContext.Customers.Remove(customer);
            _bootStrapperContext.SaveChanges();
            
        }

        public Customer GetCustomerByCustomerID(int id)
        {
            if (id == 0)
                throw new ArgumentException("Invalid id Parameter");
            var customer = _bootStrapperContext.Customers.SingleOrDefault(Customer => Customer.CustomerId == id);
            if (customer == null)
                throw new Exception("Error getting Customer record.");
            return customer;
        }
    }
}
