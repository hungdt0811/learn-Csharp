using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_CORE_05
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache(); // Dang ky service section
            services.AddSession(option => {
                option.Cookie.Name = "hungdang"; // ten Coookie
                option.IdleTimeout = new TimeSpan(0, 30, 0); // hieu luc trong 30p
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession(); // Section Middleware

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    int? count;  // luu trong sesstion

                    // Doc du lieu trong sesstion
                    count = context.Session.GetInt32("count");

                    if(count == null) {
                        // lan truy cap dau tien
                        count = 0;
                    }
                    await context.Response.WriteAsync($"So lan truy cap readwritesesstion la: {count}");
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/readwritesesstion", async context =>
                {
                    int? count;  // luu trong sesstion

                    // Doc du lieu trong sesstion
                    count = context.Session.GetInt32("count");

                    if(count == null) {
                        // lan truy cap dau tien
                        count = 0;
                    }
                    
                    count += 1;
                    // Ghi du lieu vao sesstion
                    context.Session.SetInt32("count", count.Value);

                    await context.Response.WriteAsync($"So lan truy cap readwritesesstion la: {count}");
                });
            });
        }
    }
}
