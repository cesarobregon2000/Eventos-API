using Eventos.Applications.Common.Interfaces;
using Eventos.Infraestructures.Data.SQL;
using Eventos.Infraestructures.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.Infraestructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection")
                ?? throw new ArgumentNullException(nameof(configuration));

            services.AddScoped(x => new SQLContext(connectionString));

            services.AddScoped<IDatosEventosRepository, DatosEventosRepository>();

            return services;
        }
    }
}