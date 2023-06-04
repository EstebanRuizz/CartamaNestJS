using Microsoft.Extensions.DependencyInjection;
using Parque.Application.Interfaces;
using Parque.Shared.DatetimeService;

namespace Parque.Shared
{
    public static class ServicesExtenisions
    {
        public static void AddIOCSharedLayer(this IServiceCollection services)
        {
            #region Services

            services.AddTransient<IDateTimeService, DateTimeService>();
            #endregion
        }
    }
}
