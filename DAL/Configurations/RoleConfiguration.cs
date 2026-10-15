using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(r => r.Name)
                   .IsUnique();

           
            builder.Property(r => r.RoleType)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(r => r.IsGlobal)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Soft delete filter
            builder.HasQueryFilter(r => !r.IsDeleted);

            // Seed: built-in global roles
            builder.HasData(
                new Role { Id = 1, Name = "Owner",         RoleType = RoleType.Owner,         IsGlobal = true,  CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 2, Name = "Head of HR",    RoleType = RoleType.HeadOfHR,       IsGlobal = true,  CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 3, Name = "Head of Finance",RoleType = RoleType.HeadOfFinance,  IsGlobal = true,  CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 4, Name = "Head of Ops",   RoleType = RoleType.HeadOfOps,      IsGlobal = true,  CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 5, Name = "Admin",         RoleType = RoleType.Admin,          IsGlobal = true,  CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 6, Name = "Branch Manager",RoleType = RoleType.BranchManager,  IsGlobal = false, CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 7, Name = "HR",            RoleType = RoleType.HR,             IsGlobal = false, CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 8, Name = "Finance",       RoleType = RoleType.Finance,        IsGlobal = false, CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 9, Name = "Junior Manager",RoleType = RoleType.JuniorManager,  IsGlobal = false, CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 10, Name = "Employee",     RoleType = RoleType.Employee,       IsGlobal = false, CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 11, Name = "Courier",      RoleType = RoleType.Courier,        IsGlobal = false, CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Role { Id = 12, Name = "Customer",     RoleType = RoleType.Customer,       IsGlobal = true,  CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
