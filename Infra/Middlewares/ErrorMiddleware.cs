using System.Text.Json;

namespace WebExercicios.Middlewares;
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
        catch (Exception ex)
        {
            await Tratarrro(ex,context);
        }
    }

    public static Task Tratarrro(Exception ex, HttpContext context)
    {
        string stackTrace;
        string message;
        int code;

        message = ex.Message;
        stackTrace = ex.StackTrace;
        code = context.Response.StatusCode;
        var result = JsonSerializer.Serialize(new { message, code, stackTrace });
        return context.Response.WriteAsync(result);
    }
}
