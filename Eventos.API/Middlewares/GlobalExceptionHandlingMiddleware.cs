using Eventos.Applications.Common.Feactures;
using System.Text.Json;

namespace Eventos.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        public GlobalExceptionHandlingMiddleware() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var response = Result<string>.Fail(ex.Errors.Select(e => e.ErrorMessage).ToList(), "Error de validación");
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (KeyNotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";
                var response = Result<string>.NotFound(ex.Message);
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }//No se encontraron resultados

            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = Result<string>.Fail(ex.Message, "Error interno del servidor");

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
