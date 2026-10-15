using BAL.dto.organization;
using BAL.Interfaces;
using CMS.Extensions;
using CMS.SwaggerExamples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Swashbuckle.AspNetCore.Filters;

namespace CMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost("createOrganization")]
        [EnableRateLimiting(RateLimiterExtensions.CreateOrganizationPolicy)]
        [SwaggerRequestExample(typeof(CreateOrganizationDto), typeof(CreateOrganizationDtoExample))]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _organizationService.CreateOrganizationAsync(dto);
                return CreatedAtAction(nameof(GetOrganizationById), new { id = result.Id }, new
                {
                    success = true,
                    message = "Organization created successfully.",
                    data = result
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    success = false,
                    message = "An unexpected error occurred while creating the organization.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("{id:int}")]
        [EnableRateLimiting(RateLimiterExtensions.GeneralPolicy)]
        public async Task<IActionResult> GetOrganizationById(int id)
        {
            var result = await _organizationService.GetOrganizationByIdAsync(id);
            if (result == null)
            {
                return NotFound(new { success = false, message = $"Organization with ID {id} not found." });
            }

            return Ok(new { success = true, data = result });
        }
    }
}
