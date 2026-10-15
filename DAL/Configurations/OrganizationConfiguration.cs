using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.HasIndex(o => o.Name)
                   .IsUnique();

            builder.Property(o => o.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(o => o.Email)
                   .IsUnique();

            builder.Property(o => o.Phone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(o => o.Address)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(o => o.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(o => o.IsActive)
                   .HasDefaultValue(true);

            builder.Property(o => o.OwnerId)
                   .IsRequired(false);

            builder.HasQueryFilter(o => !o.IsDeleted);

            builder.HasOne(o => o.Owner)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(false);

            builder.HasMany(o => o.Users)
                   .WithOne(u => u.Organization)
                   .HasForeignKey(u => u.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Branches)
                   .WithOne(b => b.Organization)
                   .HasForeignKey(b => b.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
