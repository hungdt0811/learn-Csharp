using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_CORE_02
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SecondMiddleware>(); // đăng ký middleware tạo từ Interface
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();           // đưa vào pipeline satatic file middleware 
            app.UseFirstMiddleware();       // đưa vào pipeline First middleware
            app.UseSecondtMiddleware();     // đưa vào pipeline Second middleware

            app.UseRouting();   // EndpointRoutingMiddleware 

            // Tạo các Endpoint (Terminal middleware)
            app.UseEndpoints((endpoint) => {
                endpoint.MapGet("/about.html", async context => {
                    await context.Response.WriteAsync("Trang gioi thieu");
                });
                endpoint.MapGet("/product.html", async context => {
                    await context.Response.WriteAsync("Trang san pham");
                });
                //...
            });

            // Rẽ nhánh pipeline
            app.Map("/admin", (app1)  => {
                // Tạo middleware của nhánh
                app1.UseRouting();   // EndpointRoutingMiddleware 

                // Tạo các Endpoint (Terminal middleware)
                app1.UseEndpoints((endpoint) => {
                endpoint.MapGet("/product.html", async context => {
                    await context.Response.WriteAsync("Trang quan tri san pham");
                });
                endpoint.MapGet("/blog.html", async context => {
                    await context.Response.WriteAsync("Trang quan tri bai viet");
                });
                //...
            });

                // Terminal Middleware
                app1.Run(async (context) => {
                    await context.Response.WriteAsync("Middleware Cuoi Cung 1");
                });
            });

            // Terminal Middleware
            app.Run(async (context) => {
                await context.Response.WriteAsync("Middleware Cuoi Cung 2");
            });
        }
    }
}
