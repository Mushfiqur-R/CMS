using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(b => b.Address)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(b => b.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.District)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Phone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(b => b.BranchType)
                   .IsRequired();

            builder.Property(b => b.IsActive)
                   .HasDefaultValue(true);

            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.HasOne(b => b.Organization)
                   .WithMany(o => o.Branches)
                   .HasForeignKey(b => b.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Manager)
                   .WithMany()
                   .HasForeignKey(b => b.ManagerId)
                   .OnDelete(DeleteBehavior.SetNull)
                   .IsRequired(false);
        }
    }
}
