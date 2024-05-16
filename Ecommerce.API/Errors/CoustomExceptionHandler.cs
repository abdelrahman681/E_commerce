using System.Net;
using System.Text.Json;

namespace E_commerce.API.Errors
{
    public class CoustomExceptionHandler
    {
        private readonly RequestDelegate _message;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<CoustomExceptionHandler> _logger;

        public CoustomExceptionHandler(RequestDelegate message, ILogger<CoustomExceptionHandler> logger, IHostEnvironment environment )
        {
            _message = message;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _message.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                var res = _environment.IsDevelopment() ? new APIExceptionResponse
                    ((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace) : new APIExceptionResponse
                    ((int)HttpStatusCode.InternalServerError);

                //context.Response.ContentType = "application/json";
                //var json=JsonSerializer.Serialize(res,new JsonSerializerOptions { PropertyNamingPolicy=JsonNamingPolicy.CamelCase});
                //await context.Response.WriteAsync(json);

                await context.Response.WriteAsJsonAsync(res);//Change the three methods above
            }
        }
    }
}
