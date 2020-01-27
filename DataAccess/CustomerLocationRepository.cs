using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class CustomerLocationRepository : ICustomerLocationRepository
    {
        private readonly IConnection _connection;


        public CustomerLocationRepository(IConnection connection)
        {
            _connection = connection;
        }
        public List<CustomerLocation> GetAllCustomerLocations()
        {
            string sql = "SELECT * FROM CustomerLocations";

            using (var connection = new SqlConnection(_connection.DataConnection))
            {
                var customerLocations = connection.Query<CustomerLocation>(sql).ToList();

                Console.WriteLine(customerLocations.Count);
                return customerLocations;
            }
        }

        public List<CustomerLocation> GetCustomerLocationsCustomerLocationByCustomerId(int Id)
        {
            string sql = "SELECT * FROM CustomerLocations where CustomerId = @CustomerId";

            using (var connection = new SqlConnection(_connection.DataConnection))
            {
                var customerLocations = connection.Query<CustomerLocation>(sql, new { CustomerId = Id }).ToList();

                Console.WriteLine(customerLocations.Count);
                return customerLocations;
            }
        }
    }
}
