using ASPNET_API.Models;
using AutoMapper;
using DataAccess;

namespace ASPNET_API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
