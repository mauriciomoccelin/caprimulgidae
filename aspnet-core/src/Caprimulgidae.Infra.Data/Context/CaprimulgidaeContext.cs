using Antilopes.Common.Helpers.AppSettings;
using Caprimulgidae.Domain.Models.AreasConhecimentos;
using Caprimulgidae.Domain.Models.Estimativas;
using Caprimulgidae.Domain.Models.Eventos;
using Caprimulgidae.Domain.Models.Usuarios;
using Caprimulgidae.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Caprimulgidae.Infra.Data.Context
{
    public class CaprimulgidaeContext : DbContext
    {
        private readonly IAppSettingsHelper appSettingsHelper;

        public CaprimulgidaeContext()
        {
            appSettingsHelper = new AppSettingsHelper();
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AreaConhecimento> AreaConhecimentos { get; set; }
        public DbSet<Estimativa> Estimativas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AreaConhecimentoMap());
            modelBuilder.ApplyConfiguration(new EstimativaMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(appSettingsHelper.GetConnectionString());
    }
}
