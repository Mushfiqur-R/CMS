using DAL.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ── DbSets 
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelStatusHistory> ParcelStatusHistories { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all IEntityTypeConfiguration classes from this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
