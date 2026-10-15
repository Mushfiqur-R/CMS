using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(ur => ur.Id);

            builder.HasIndex(ur => new { ur.UserId, ur.RoleId, ur.BranchId }).IsUnique();

            builder.Property(ur => ur.BranchId)
                   .IsRequired(false);

            builder.Property(ur => ur.AssignedByUserId)
                   .IsRequired(false);

            builder.Property(ur => ur.AssignedAt)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(ur => ur.User)
                   .WithMany(u => u.UserRoles)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

           
            builder.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.Branch)
                   .WithMany()
                   .HasForeignKey(ur => ur.BranchId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);

            builder.HasOne(ur => ur.AssignedBy)
                   .WithMany()
                   .HasForeignKey(ur => ur.AssignedByUserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(false);


            builder.HasIndex(ur => ur.UserId);
            builder.HasIndex(ur => new { ur.BranchId, ur.RoleId });

            // Global query filter to match Role and User soft-delete filters
            builder.HasQueryFilter(ur => !ur.Role.IsDeleted && !ur.User.IsDeleted);
        }
    }
}
