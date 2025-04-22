using microprojeto_aspnet_PersonalBudget.Models;
using Microsoft.EntityFrameworkCore;

namespace microprojeto_aspnet_PersonalBudget.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Registro> Registros { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiqueta>().HasData(
                    new Etiqueta { EtiquetaId = "alimentacao", Nome = "Alimentação" },
                    new Etiqueta { EtiquetaId = "transporte", Nome = "Transporte" },
                    new Etiqueta { EtiquetaId = "saude", Nome = "Saúde" },
                    new Etiqueta { EtiquetaId = "moradia", Nome = "Moradia" },
                    new Etiqueta { EtiquetaId = "lazer", Nome = "Lazer" }
                );

            modelBuilder.Entity<Status>().HasData(
                    new Status { StatusId = "pago", Nome = "Pago" },
                    new Status { StatusId = "nao-pago", Nome = "Não Pago" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
