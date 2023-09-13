using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Application.Services;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class InjectionDependency
    {
        public static void AddInfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LoginDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStringSQLServer"));
            });

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<IUserCommand, UserCommand>();

        }
    }
}
