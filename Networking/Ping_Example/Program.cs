using System.Net.NetworkInformation;
using System.Text;

namespace Ping_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Lớp Ping trong .Net");
            Console.WriteLine("-------------------");


            var ping = new Ping();
            var pingReply = ping.Send("carly.com.vn");
            Console.WriteLine(pingReply.Status);

            if(pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
                Console.WriteLine(pingReply.Address);
            }
        }
    }
}
 