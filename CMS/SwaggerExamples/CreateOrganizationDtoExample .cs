using BAL.dto.organization;
using Swashbuckle.AspNetCore.Filters;

namespace CMS.SwaggerExamples
{
    public class CreateOrganizationDtoExample : IExamplesProvider<CreateOrganizationDto>
    {
        public CreateOrganizationDto GetExamples()
        {
            return new CreateOrganizationDto
            {
         
                Name = "ABC Technologies Ltd.",
                Email = "info@abctech.com",
                Phone = "01712345678",
                Address = "House 12, Road 5, Dhanmondi",
                City = "Dhaka",
                OwnerFullName = "Rahim Uddin",
                OwnerEmail = "rahim@abctech.com",
                OwnerPhone = "01812345678",
                OwnerPassword = "Pass@123456"
            };
        }
    }
}
