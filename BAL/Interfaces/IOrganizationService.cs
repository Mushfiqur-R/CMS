using BAL.dto.organization;

namespace BAL.Interfaces
{
    public interface IOrganizationService
    {
        Task<OrganizationResponseDto> CreateOrganizationAsync(CreateOrganizationDto dto);
        Task<OrganizationResponseDto?> GetOrganizationByIdAsync(int id);
    }
}
