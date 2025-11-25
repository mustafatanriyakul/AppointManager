using AppointManager.Backend.Domain.Entities;
using AppointManager.Backend.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppointManager.Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments => Set<Appointment>();

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CompanyAdmin> CompanyAdmins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(customer => customer.UserId);

                entity.HasOne(customer => customer.ApplicationUser)
                      .WithOne()
                      .HasForeignKey<Customer>(customer => customer.UserId);
            });

            builder.Entity<CompanyAdmin>(entity =>
            {
                entity.HasKey(companyAdmin => companyAdmin.UserId);

                entity.HasOne(companyAdmin => companyAdmin.ApplicationUser)
                    .WithOne()
                    .HasForeignKey<CompanyAdmin>(companyAdmin => companyAdmin.UserId);
            });


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
