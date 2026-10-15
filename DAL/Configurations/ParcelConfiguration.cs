using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.ToTable("Parcels");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.TrackingNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(p => p.TrackingNumber)
                   .IsUnique();

            builder.Property(p => p.ReceiverName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.ReceiverPhone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(p => p.ReceiverAddress)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.ReceiverCity)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.ReceiverDistrict)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Weight)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Length)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Width)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Height)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.DeclaredValue)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.ServiceType)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasDefaultValue(ParcelStatus.Pending)
                   .HasSentinel((ParcelStatus)0);

            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasOne(p => p.SenderUser)
                   .WithMany()
                   .HasForeignKey(p => p.SenderUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Organization)
                   .WithMany()
                   .HasForeignKey(p => p.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.OriginBranch)
                   .WithMany(b => b.OutgoingParcels)
                   .HasForeignKey(p => p.OriginBranchId)
                   .OnDelete(DeleteBehavior.SetNull)
                   .IsRequired(false);

            builder.HasOne(p => p.DestinationBranch)
                   .WithMany(b => b.IncomingParcels)
                   .HasForeignKey(p => p.DestinationBranchId)
                   .OnDelete(DeleteBehavior.SetNull)
                   .IsRequired(false);

            builder.HasOne(p => p.AssignedCourier)
                   .WithMany(c => c.AssignedParcels)
                   .HasForeignKey(p => p.AssignedCourierId)
                   .OnDelete(DeleteBehavior.SetNull)
                   .IsRequired(false);

            builder.HasOne(p => p.Payment)
                   .WithOne(pay => pay.Parcel)
                   .HasForeignKey<Payment>(pay => pay.ParcelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.StatusHistories)
                   .WithOne(h => h.Parcel)
                   .HasForeignKey(h => h.ParcelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
