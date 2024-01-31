using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_CORE_04
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ProductName>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/ShowOptions", async context =>
                {
                    var myProductNameService = context.RequestServices.GetService<ProductName>();

                    var stringBuilder = new StringBuilder();

                    myProductNameService.GetName().ForEach((name) => {
                        stringBuilder.Append(name + "\n");
                    });

                    await context.Response.WriteAsync(stringBuilder.ToString());

                    // var configuration = context.RequestServices.GetService<IConfiguration>();
                    // var testOptions = configuration.GetSection("TestOptions").Get<TestOptions>();
                    
                    // // var opt_key1 = testOptions["opt_key1"];

                    // // var k1 = testOptions.GetSection("opt_key2")["k1"];
                    // // var k2 = testOptions.GetSection("opt_key2")["k2"];

                    // var stringBuilder = new StringBuilder();

                    // stringBuilder.Append("TESTOPTIONS \n");
                    // stringBuilder.Append($"opt_key1 = {testOptions.opt_key1} \n");
                    // stringBuilder.Append($"TestOptions.otp_key2.k1 = {testOptions.opt_key2.k1} \n");
                    // stringBuilder.Append($"TestOptions.otp_key2.k2 = {testOptions.opt_key2.k2} ");

                    // await context.Response.WriteAsync(stringBuilder.ToString());
                });
            });
        }
    }
}
