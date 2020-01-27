using ASPNET_API.Models;
using AutoMapper;
using DataAccess;
using DataAccess.Models;

namespace ASPNET_API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerLocation, LocationDTO>();
        }
    }
}
