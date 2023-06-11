using Parque.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace Parque.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new GenericResponse<string>() { Succeed = false, Message = error?.Message };
                switch (error)
                {
                    case Application.Exceptions.ValidationException e:
                        //Error de validacion cuando reglas de negocio
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case Application.Exceptions.ApiException e:
                        //Error controlado por la API
                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        break;

                    case KeyNotFoundException e:
                        //Llave no encontrado
                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        break;

                    case UnauthorizedAccessException e:
                        //No se encuentra con los permisos requeridos
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;

                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
