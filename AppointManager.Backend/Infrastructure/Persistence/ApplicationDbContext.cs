using AppointManager.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments => Set<Appointment>();
    }
}
