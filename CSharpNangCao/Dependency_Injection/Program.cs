using System.Text;
using Inverted_Dependency;
// using Tham_Chieu_Truc_Tiep_Den_Dependency;

namespace Dependency_Injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Dependency injection trong C#");
            Console.WriteLine("-----------------------------");

            // Tham chiếu trực tiếp đến dependency
            IClassC objC = new ClassC();
            IClassB objB = new ClassB(objC);
            ClassA objA = new ClassA(objB);

            objA.CongViecA();

            // Inverse Dependency
            
        }

    }
}
