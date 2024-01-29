using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SecondMiddleware : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) 
    {
        if(context.Request.Path == "/xxx.html") {
            context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
            var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"]; // lấy dữ liệu từ Middleware trước
            if(dataFromFirstMiddleware != null) {
                await context.Response.WriteAsync($"<h1>{(string)dataFromFirstMiddleware}</h1>");
            }
            await context.Response.WriteAsync("Ban khong co quyen truy cap");
        }
        else {
            context.Response.Headers.Add("SecondMiddleware", "Ban duoc quyen truy cap");
            await next(context);
        }
    }
}