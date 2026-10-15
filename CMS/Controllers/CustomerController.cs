//using BAL.dto.customer;
//using BAL.Interfaces;
//using Domain.Entities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;

//namespace CMS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly ICustomerService _customerService;

//        public CustomerController(ICustomerService customerService)
//        {
//            this._customerService = customerService;
//        }


//        [HttpGet("getallcustomers")]
//        public async Task<IActionResult> GetCustomerAsync()
//        {
//           var customers= await _customerService.GetallCustomer();
//            return Ok(customers);
//        }

//        [HttpPost("createCustomer")]
//        public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
//        {
//            var customer=await _customerService.CreateCustomerAsync(dto);
//            return Ok(new
//            {
//                Message="New Customer created Successfully",
//                Data=customer
//            });
//        }
//    }
//}
