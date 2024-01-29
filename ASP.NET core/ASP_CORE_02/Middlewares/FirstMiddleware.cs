using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class FirstMiddleware 
{
    private readonly RequestDelegate _next;
    // RequestDelegate => async (HttpContext context) => {}
    public FirstMiddleware(RequestDelegate next) {
        _next = next;
    }

    // Được gọi khi HttpContext đi qua middleware
    public async Task InvokeAsync(HttpContext context) {
        Console.WriteLine(context.Request.Path);
        context.Items.Add("DataFirstMiddleware", "Du lieu duoc truyen tu FirstMiddleware");
        // await context.Response.WriteAsync("<h1>Tieu de duoc tao boi First Middleware</h1>");

        // Gọi middleware tiếp theo
        await _next(context);
    }
}

