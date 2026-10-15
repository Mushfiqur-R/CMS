//using AutoMapper;
//using BAL.dto.customer;
//using BAL.Interfaces;
//using DAL.Interfaces;
//using DAL.Repositories;
//using Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BAL.Services
//{
//    public class CustomerService : ICustomerService
//    {
//        private readonly ICustomerRepository _customerRepository;
//        private readonly IMapper _mapper;

//        public CustomerService(ICustomerRepository customerRepository,IMapper _mapper)
//        {
//            this._customerRepository = customerRepository;
//            this._mapper = _mapper;

//        }

//        public async Task<CreateCustomerDto> CreateCustomerAsync(CreateCustomerDto dto)
//        {
//            var newcustomer = _mapper.Map<Customer>(dto);
//            await _customerRepository.CreateCustomerAsync(newcustomer);
//            return _mapper.Map<CreateCustomerDto>(dto);
//        }

//        public async Task<List<Customer>> GetallCustomer()
//        {
//            return await _customerRepository.GetAllCustomerAsync();
//        }
//    }
//}
