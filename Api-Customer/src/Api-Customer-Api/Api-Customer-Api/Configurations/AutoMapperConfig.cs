using Api_Customer_Api.ViewModels;
using Api_Customer_Domain.Entities;
using AutoMapper;

namespace Api_Customer_Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
        }
    }
}
