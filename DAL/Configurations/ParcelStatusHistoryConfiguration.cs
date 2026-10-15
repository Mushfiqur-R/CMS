using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ParcelStatusHistoryConfiguration : IEntityTypeConfiguration<ParcelStatusHistory>
    {
        public void Configure(EntityTypeBuilder<ParcelStatusHistory> builder)
        {
            builder.ToTable("ParcelStatusHistories");
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).ValueGeneratedOnAdd();

            builder.Property(h => h.Status)
                   .IsRequired();

            builder.Property(h => h.Location)
                   .HasMaxLength(300);

            builder.Property(h => h.Remarks)
                   .HasMaxLength(500);

            builder.HasQueryFilter(h => !h.IsDeleted);

            builder.HasOne(h => h.ChangedByUser)
                   .WithMany()
                   .HasForeignKey(h => h.ChangedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
