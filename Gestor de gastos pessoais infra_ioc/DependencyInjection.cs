using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gestor_de_gastos_pessoais_data.Contexto;
using Microsoft.EntityFrameworkCore;
using Gestor_de_gastos_pessoais_data.Identity;
using Gestor_de_gastos_pessoais_data.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces.InterfacesIdentity;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces;
using Gestor_de_gastos_pessoais_data.Repository;

namespace Gestor_de_gastos_pessoais_infra_ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfiguracaoServices(this IServiceCollection services, IConfiguration configuration)
        {
            // iniciano identity no banco


            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("Admin",
                    politica =>
                    {
                        politica.RequireRole("Admin");
                    });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("coneccaoComBanco"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(4);
            });
            services.AddScoped<UserManager<UsuarioSistema>>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<IGastosRepository, GastoRepository>();
            services.AddScoped<ITipoGastosRepository, TipoGastosRepository>();
            services.AddScoped<ILocalGastosRepository, LocalGastosRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
            });
            return services;
        }

    }

}
