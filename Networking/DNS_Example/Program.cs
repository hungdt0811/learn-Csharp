using System.Net;
using System.Text;

namespace DNS_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Lớp tĩnh DNS và lớp IPHostEntry");
            Console.WriteLine("-------------------------------");

            // lấy host name của máy đnag chạy
            var hostname = Dns.GetHostName();
            Console.WriteLine(hostname);

            var url = "https://carly.com.vn/";
            var uri = new Uri(url);
            Console.WriteLine(uri.Host);

            var iphostentry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine(iphostentry.HostName);
            iphostentry.AddressList
                .ToList()
                .ForEach(ip =>
                {
                    Console.WriteLine(ip);
                });
        }
    }
}
