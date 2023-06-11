using Parque.WebApi.Middleware;

namespace Parque.WebApi.Extensions
{
    public static class ApiExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
