using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PMS.Dtos;
using PMS.Models;

namespace PMS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        Mapper.CreateMap<Customer, CustomerDto>();
        Mapper.CreateMap<Product, ProductDto>();
        Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        Mapper.CreateMap<Category, CategoryDto>();
        Mapper.CreateMap<ProductDto, Product>().ForMember(c => c.Id, opt => opt.Ignore());
        Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
    }
    }
}