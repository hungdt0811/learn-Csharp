using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_CORE_03
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

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                        new object[] {
                            new {
                                url = "/abc",
                                label = "Menu Abc"
                            },
                            new {
                                url = "/xyz",
                                label = "Menu Xyz"
                            }
                        } , context.Request
                    );
                    var html = HtmlHelper.HtmlDocument("Đây là title", menu + "Hello world".HtmlTag("h1", "text-danger"));

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/RequestInfor", async (context) => {
                    await context.Response.WriteAsync("RequestInfor");
                });
                endpoints.MapGet("/Encoding", async (context) => {
                    await context.Response.WriteAsync("Encoding");
                });
                endpoints.MapGet("/Cookie", async (context) => {
                    await context.Response.WriteAsync("Cookie");
                });
                endpoints.MapGet("/Json", async (context) => {
                    await context.Response.WriteAsync("Json");
                });
                endpoints.MapGet("/Form", async (context) => {
                    await context.Response.WriteAsync("Form");
                });
            });
        }
    }
}
