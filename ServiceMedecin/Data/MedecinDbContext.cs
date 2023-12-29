using Microsoft.EntityFrameworkCore;
using ServiceMedecin.Models;

namespace ServiceMedecin.Data
{
    public class MedecinDbContext : DbContext
    {
        public MedecinDbContext(DbContextOptions<MedecinDbContext> options) : base(options)
        {
        }

        public DbSet<Medecin> Medecins { get; set; }
    }
}
