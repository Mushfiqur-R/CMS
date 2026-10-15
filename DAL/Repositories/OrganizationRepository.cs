using DAL.context;
using DAL.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly AppDbContext _context;

        public OrganizationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Organization> CreateWithAdminAsync(Organization organization, User owner, int ownerRoleId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Save Organization first to generate its Id
                await _context.Organizations.AddAsync(organization);
                await _context.SaveChangesAsync();

                // 2. Link Owner to the newly created Organization and save
                owner.OrganizationId = organization.Id;
                await _context.Users.AddAsync(owner);
                await _context.SaveChangesAsync();

                // 3. Set OwnerId in Organization
                organization.OwnerId = owner.Id;

                // 4. Assign Owner role in UserRoles
                var userRole = new UserRole
                {
                    UserId = owner.Id,
                    RoleId = ownerRoleId,
                    BranchId = null,
                    AssignedAt = DateTime.UtcNow
                };
                await _context.UserRoles.AddAsync(userRole);

                await _context.SaveChangesAsync();

                // 5. Commit database transaction
                await transaction.CommitAsync();

                organization.Owner = owner;
                return organization;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Organization?> GetByIdAsync(int id)
        {
            return await _context.Organizations
                .Include(o => o.Owner)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Organizations
                .AnyAsync(o => o.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Organizations
                .AnyAsync(o => o.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> ExistsUserEmailAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<Role?> GetRoleByTypeAsync(RoleType roleType)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleType == roleType);
        }
    }
}
