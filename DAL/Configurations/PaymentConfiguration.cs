using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PaymentMethod)
                   .IsRequired();

            builder.Property(p => p.PaymentStatus)
                   .IsRequired()
                   .HasDefaultValue(PaymentStatus.Pending)
                   .HasSentinel((PaymentStatus)0);

            builder.Property(p => p.TransactionId)
                   .HasMaxLength(100);

            builder.Property(p => p.Notes)
                   .HasMaxLength(500);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
