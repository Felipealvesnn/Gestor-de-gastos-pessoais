using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gestor_de_gastos_pessoais_data.Contexto;
using Microsoft.EntityFrameworkCore;
using Gestor_de_gastos_pessoais_data.Identity;
using Gestor_de_gastos_pessoais_data.Domain.Interfaces;

namespace Gestor_de_gastos_pessoais_infra_ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfiguraçãoServices(this IServiceCollection services, IConfiguration configuration)
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

            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IAuthenticate, AuthenticateService>();


            return services;
        }

    }

}
