using Domain.Entities;

namespace DAL.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<Organization> CreateWithAdminAsync(Organization organization, User owner, int ownerRoleId);
        Task<Organization?> GetByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsUserEmailAsync(string email);
        Task<Role?> GetRoleByTypeAsync(RoleType roleType);
    }
}
