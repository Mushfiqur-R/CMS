using AutoMapper;
using BAL.dto.organization;
using BAL.Interfaces;
using DAL.Interfaces;
using Domain.Entities;

namespace BAL.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public OrganizationService(
            IOrganizationRepository organizationRepository,
            IPasswordHasher passwordHasher,
            IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<OrganizationResponseDto> CreateOrganizationAsync(CreateOrganizationDto dto)
        {
            // 1. Validation checks
            if (await _organizationRepository.ExistsByNameAsync(dto.Name))
            {
                throw new InvalidOperationException($"An organization with the name '{dto.Name}' already exists.");
            }

            if (await _organizationRepository.ExistsByEmailAsync(dto.Email))
            {
                throw new InvalidOperationException($"An organization with the email '{dto.Email}' already exists.");
            }

            if (await _organizationRepository.ExistsUserEmailAsync(dto.OwnerEmail))
            {
                throw new InvalidOperationException($"A user with the email '{dto.OwnerEmail}' already exists.");
            }

            // 2. Fetch the Owner role
            var ownerRole = await _organizationRepository.GetRoleByTypeAsync(RoleType.Owner);
            if (ownerRole == null)
            {
                throw new InvalidOperationException("System Owner role is not configured in the database.");
            }

            // 3. Prepare Organization entity
            var organization = _mapper.Map<Organization>(dto);

            // 4. Prepare Owner User entity with hashed password
            var owner = new User
            {
                FullName = dto.OwnerFullName,
                Email = dto.OwnerEmail,
                Phone = dto.OwnerPhone,
                PasswordHash = _passwordHasher.HashPassword(dto.OwnerPassword),
                IsActive = true
            };

            // 5. Transactionally persist Organization, Owner User, and UserRole
            var created = await _organizationRepository.CreateWithAdminAsync(organization, owner, ownerRole.Id);

            return _mapper.Map<OrganizationResponseDto>(created);
        }

        public async Task<OrganizationResponseDto?> GetOrganizationByIdAsync(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            return organization == null ? null : _mapper.Map<OrganizationResponseDto>(organization);
        }
    }
}
