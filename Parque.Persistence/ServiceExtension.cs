using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parque.Application.Interfaces;
using Parque.Persistence.DBcontext;
using Parque.Persistence.Repositories;

namespace Parque.Persistence
{
    public static class ServiceExtension
    {
        public static void AddIOCPersintenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParqueDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ParqueDB"),
                p => p.MigrationsAssembly(typeof(ParqueDbContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(GenericRepository<>));
            #endregion



        }
    }
}
