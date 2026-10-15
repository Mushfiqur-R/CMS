using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(u => u.Phone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(u => u.IsActive)
                   .HasDefaultValue(true);

            
            builder.Property(u => u.BranchId)
                   .IsRequired(false);

      
            builder.HasQueryFilter(u => !u.IsDeleted);


            builder.HasOne(u => u.Organization)
                   .WithMany(o => o.Users)
                   .HasForeignKey(u => u.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(u => u.HomeBranch)
                   .WithMany()
                   .HasForeignKey(u => u.BranchId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);
        }
    }
}
