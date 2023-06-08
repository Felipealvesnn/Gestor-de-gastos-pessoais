using Gestor_de_gastos_pessoais_data.Domain.Models;
using Gestor_de_gastos_pessoais_data.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Gestor_de_gastos_pessoais_data.Contexto
{
    public class AppDbContext : IdentityDbContext<UsuarioSistema>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Gastos> gastos { get; set; } = null!;
        public DbSet<TipoGastos> tipoGastos { get; set; } = null!;
        public DbSet<LocalGasto> localGastos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GastosConfiguration());
            builder.ApplyConfiguration(new TipoGastosConfiguration());
            builder.ApplyConfiguration(new LocalGastoConfiguration());
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }

}
