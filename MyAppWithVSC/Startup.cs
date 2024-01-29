using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyAppWithVSC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
                    string html = @"
                                    <!DOCTYPE html>
                                    <html>
                                    <head>
                                        <meta charset=""UTF-8"">
                                        <title>Trang web đầu tiên</title>
                                        <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                                        <script src=""/js/jquery.min.js""></script>
                                        <script src=""/js/popper.min.js""></script>
                                        <script src=""/js/bootstrap.min.js""></script>
                                    </head>
                                    <body>
                                        <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                                                <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                                                <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                                        <span class=""navbar-toggler-icon""></span>
                                                </button>
                                                <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                                                <ul class=""navbar-nav"">
                                                    <li class=""nav-item active"">
                                                        <a class=""nav-link"" href=""#"">Trang chủ</a>
                                                    </li>
                                                
                                                    <li class=""nav-item"">
                                                        <a class=""nav-link"" href=""#"">Học HTML</a>
                                                    </li>
                                                
                                                    <li class=""nav-item"">
                                                        <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                                    </li>
                                            </ul>
                                            </div>
                                        </nav> 
                                        <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                                    </body>
                                    </html>
                        ";
                    // await context.Response.WriteAsync("Home Page");
                    await context.Response.WriteAsync(html);
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
        }
    }
}
