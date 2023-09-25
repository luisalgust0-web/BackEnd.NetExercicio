using System.Diagnostics;
using System.Text.Json;
using Google.Protobuf.WellKnownTypes;
using WebExercicios.Infra.Exceptions;
using WebExercicios.Services.Base;

namespace WebExercicios.Infra.Middlewares;
public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (LocadoraFilmeException ex)
        {
            string type = "LocadoraException";
            await MessagesService(ex,context,type); 
        }
        catch (Exception ex){
            string type = "Exception";
            await MessagesService(ex,context,type);
        }
    }

     public Task MessagesService(Exception ex, HttpContext context, string typeMessage)
    {
            string _stackTrace;
            string _message;
            string _type;
            int _statusCode;

            _message = ex.Message;
            _stackTrace = ex.StackTrace;
            _statusCode = context.Response.StatusCode;
            _type = typeMessage;
            var result = JsonSerializer.Serialize(new { _message, _statusCode, _stackTrace, _type });

            return context.Response.WriteAsync(result);
    }


}

