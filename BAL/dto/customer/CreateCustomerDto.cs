using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.dto.customer
{
    public class CreateCustomerDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
