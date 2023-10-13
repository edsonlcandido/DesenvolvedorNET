using DesenvolvedorNET.Models;
using Microsoft.EntityFrameworkCore;

namespace DesenvolvedorNET.Db
{
    public class DesenvolvedorNETContext : DbContext
    {
        public DesenvolvedorNETContext(DbContextOptions<DesenvolvedorNETContext> options)
            : base(options)
        {
        }

        public DbSet<Empregado> Empregados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empregado>().ToTable("Empregados");
            modelBuilder.Entity<Empregado>().HasKey(e => e.Id);
        }
    }
}
