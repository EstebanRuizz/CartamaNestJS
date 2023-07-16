using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Parque.Application.Behaviours;
using System.Reflection;

namespace Parque.Application
{
    public static class ServiceExtensions
    {
        public static void AddIOCApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(p => p.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
