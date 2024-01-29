using System.Text;

namespace Uri_Class_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Địa chỉ Url và lớp Uri");
            Console.WriteLine("----------------------");

            string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            var uri = new Uri(url);
            var uriType = typeof(Uri);

            uriType.GetProperties()
                .ToList()
                .ForEach(p =>
                {
                    Console.WriteLine($"{p.Name} : {p.GetValue(uri)}");
                });
        }
    }
}
