namespace ASP.NET_Core_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Bước 1
            IHostBuilder builder = Host.CreateDefaultBuilder(args);

            // Bước 2: Cấu hình mặc định cho host tạo ra
            builder.ConfigureWebHostDefaults(
                (IWebHostBuilder webBuilder) =>
                {
                    // Tùy biến thêm về host
                    //webBuilder.
                    webBuilder.UseWebRoot("public");
                    webBuilder.UseStartup<MyStartUp>();
                });

            // Bước 3
            IHost host = builder.Build();

            // Bước 4
            host.Run();
        } 
    }
}
