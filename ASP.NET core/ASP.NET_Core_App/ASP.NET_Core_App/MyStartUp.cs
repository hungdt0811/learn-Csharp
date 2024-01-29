namespace ASP.NET_Core_App
{
    public class MyStartUp
    {
        // Đăng ký các dịch vụ sử dụng DI
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton
        }

        // Xây dựng pipeline (chuỗi middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {

            // wwwroot : static file 
            // staticMiddleware cho phép truy cập những file tĩnh như CSS, JS
            app.UseStaticFiles();

            // EndpointRoutingMiddleware
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // GET /
                endpoints.MapGet("/", async (context) =>
                {

                    await context.Response.WriteAsync("Home Page");

                });

                endpoints.MapGet("/about", async (context) =>
                {
                    await context.Response.WriteAsync("About Page");
                });

                endpoints.MapGet("/contact", async (context) =>
                {
                    await context.Response.WriteAsync("Contact Page");
                });
            });

            // StatusCodePages
            app.UseStatusCodePages();


            
            // Terminate Middleware - middleware cuối cùng
            app.Map("/abc", app1 =>
            {
                app1.Run(async (HttpContext context) =>
                {
                    await context.Response.WriteAsync("ABC Page");
                });
            });

            // Terminate Middleware - middleware cuối cùng
            //app.Run(async (HttpContext context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!!!");
            //});           
        }
    }
}
