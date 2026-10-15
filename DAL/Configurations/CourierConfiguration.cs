using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CourierConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.ToTable("Couriers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.NationalId)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(c => c.NationalId)
                   .IsUnique();

            builder.Property(c => c.VehicleNumber)
                   .HasMaxLength(20);

            builder.Property(c => c.VehicleType)
                   .IsRequired();

            builder.Property(c => c.IsAvailable)
                   .HasDefaultValue(true);

            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasOne(c => c.User)
                   .WithOne()
                   .HasForeignKey<Courier>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Organization)
                   .WithMany()
                   .HasForeignKey(c => c.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.AssignedBranch)
                   .WithMany(b => b.Couriers)
                   .HasForeignKey(c => c.AssignedBranchId)
                   .OnDelete(DeleteBehavior.SetNull)
                   .IsRequired(false);
        }
    }
}
