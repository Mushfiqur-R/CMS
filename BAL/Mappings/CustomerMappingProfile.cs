using AutoMapper;
using BAL.dto.customer;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Mappings
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile() {
            //CreateMap<CreateCustomerDto, Customer>().ReverseMap();
           
        }
    }
}
