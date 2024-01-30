using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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
                        HtmlHelper.DefaultMenuTopItems(),
                        context.Request
                    );
                    var html = HtmlHelper.HtmlDocument("Trang chủ", menu + HtmlHelper.HtmlTrangchu());

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/RequestInfo", async (context) =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(),
                        context.Request
                    );

                    // context.Request
                    var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div", "container");

                    var html = HtmlHelper.HtmlDocument("Thông tin request", menu + info);

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/Json", async (context) =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(),
                        context.Request
                    );

                    // Json
                    var p = new
                    {
                        TenSP = "Dong ho Abc",
                        Gia = 5000000,
                        NgaySX = new DateTime(2020, 01, 30)
                    };
                    // Thiết lập cho client biết nội dung trả về là JSON
                    context.Response.ContentType = "application/json";
                    // Convert to Json
                    var json = JsonConvert.SerializeObject(p);

                    await context.Response.WriteAsync(json);
                });


                endpoints.MapGet("/Cookies/{*action}", async (context) =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(),
                        context.Request
                    );

                    // lấy giá trị action
                    var actionValue = context.GetRouteValue("action") ?? "";
                    string message = "";
                    if (actionValue.ToString() == "write")
                    {
                        // Cookies option
                        var option = new CookieOptions() {
                            Path = "/",                         // duong dan ma cookies co hieu luc
                            Expires = DateTime.Now.AddDays(1)   // Thoi diem het han sau 1 ngay
                        };
                        // <tên cookie> - <giá trị> - <thời gian hiệu lực của cookie>
                        context.Response.Cookies.Append("masanpham", "123", option);
                        message = "Cookie da duoc ghi"
                                    .HtmlTag("div", "alert alert-info container");
                    }
                    else if(actionValue.ToString() == "read")
                    {
                        // Lấy danh sách các Header và giá trị  của nó, dùng Linq để lấy
                        var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                        message = string.Join("", listcokie).HtmlTag("ul")
                                    .HtmlTag("div", "alert alert-danger container");

                    }

                    var huongdan = @"<a href='/Cookies/write'>Ghi Cookie</a><br>
                                    <a href='/Cookies/read'>Doc Cookie</a>".HtmlTag("div", "container");
                   
                    var html = HtmlHelper.HtmlDocument("Cookies", menu + huongdan + message);

                    await context.Response.WriteAsync(html);
                });

                
                endpoints.MapGet("/Form", async (context) =>
                {
                    await context.Response.WriteAsync("Form");
                });

                endpoints.MapGet("/Encoding", async (context) =>
                {
                    await context.Response.WriteAsync("Encoding");
                });
            });
        }
    }
}
