using ExamGlobalApi.Services;
using System.Net;
using System.Text.Json;

namespace ExamGlobalApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogerService _loger;

        public ExceptionMiddleware(RequestDelegate next, ILogerService loger)
        {
            _next = next;
            _loger = loger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
              await  _next(context);
            }
            catch (Exception ex)
            {
                //log
                _loger.LogInfo("Hata Mesajı=" + ex.Message + "***" + "Hata Url=" + context.Request.Path +"***"+context.Request.Method);
                
                await HandleExceptionAsync(context, ex);
            }
            
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            
            //var response = new { error = exception.Message };
            //ya da
            var response = new 
            { 
                error = new 
                { 
                    message = "bla bla bla", 
                    details = exception.Message 
                }
            };
            //var result = JsonConvert.SerializeObject(response);
            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
