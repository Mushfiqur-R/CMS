using AutoMapper;
using BAL.dto.organization;
using Domain.Entities;

namespace BAL.Mappings
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {
            CreateMap<CreateOrganizationDto, Organization>().ReverseMap();
            CreateMap<Organization, OrganizationResponseDto>();
            
        }
    }
}
