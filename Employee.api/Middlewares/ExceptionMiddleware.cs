using Employee.api.CustomExceptions;

namespace Employee.api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {


            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");

                context.Response.ContentType = "application/json";
                int statuscode = 500;
                string message = "Internal Server Error";

                if (ex is AppException appx)
                {
                    statuscode = appx.StatusCode;
                    message = appx.Message;
                }
               
                context.Response.StatusCode = statuscode;
                

                var response = new
                {
                    Success = false,
                    Message = message,
                    ErrorType = ex.GetType().Name,
                    TraceId = context.TraceIdentifier
                };

                await context.Response.WriteAsJsonAsync(response);


            }

        }
    }
}
