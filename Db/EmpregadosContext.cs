using DesenvolvedorNET.Models;
using DesenvolvedorNET.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesenvolvedorNET.Db
{
    public class EmpregadosContext : DbContext
    {
        public EmpregadosContext(DbContextOptions<EmpregadosContext> options)
            : base(options)
        {
        }

        public DbSet<Empregado> Empregados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Empregado>();
            //seed data for departamentos
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nome = "TI" },
                new Departamento { Id = 2, Nome = "RH" },
                new Departamento { Id = 3, Nome = "Financeiro" },
                new Departamento { Id = 4, Nome = "Comercial" },
                new Departamento { Id = 5, Nome = "Marketing" },
                new Departamento { Id = 6, Nome = "Administrativo" }
                            );
        }
    }
}
