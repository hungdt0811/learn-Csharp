using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyAppWithVSC
{
    public class Program
    {

        // public static void Main(string[] args)
        // {
        //     // Bước 1
        //     IHostBuilder builder = Host.CreateDefaultBuilder(args);

        //     // Bước 2: Cấu hình mặc định cho host tạo ra
        //     builder.ConfigureWebHostDefaults(
        //         (IWebHostBuilder webBuilder) =>
        //         {
        //             // Tùy biến thêm về host
        //             //webBuilder.
        //             webBuilder.UseWebRoot("public");
        //             webBuilder.UseStartup<MyStartUp>();
        //         });

        //     // Bước 3
        //     IHost host = builder.Build();

        //     // Bước 4
        //     host.Run();
        // }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // webBuilder.UseWebRoot("public");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
