using System.Collections.Generic;

namespace DataAccess
{
    public interface ICustomerLocationRepository
    {
        List<CustomerLocation> GetAllCustomerLocations();

        List<CustomerLocation> GetCustomerLocationsCustomerLocationByCustomerId(int Id);
    }
}
