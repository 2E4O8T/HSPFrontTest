using HSPFrontTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HSPFrontTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Rendezvous> Rendezvouss { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medecin> Medecins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rendezvous>();
            modelBuilder.Entity<Patient>();
            modelBuilder.Entity<Medecin>();
        }
    }
}
