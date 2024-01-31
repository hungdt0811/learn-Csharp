using System.Text;
using Inverted_Dependency;
using Microsoft.Extensions.DependencyInjection;
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
            //IClassC objC = new ClassC();
            //IClassB objB = new ClassB(objC);
            //ClassA objA = new ClassA(objB);

            //objA.CongViecA();

            // Inverse Dependency

            //Car car = new Car();
            //car.Beep();

            // Horn horn = new Horn(5);
            // Car car = new Car(horn);
            // car.Beep();

            // // Sử dụng Microsoft.Extensions.DependencyInjection
            // var services = new ServiceCollection();

            // Đăng ký service
            // Interface ClassC triển khai ClassC và ClassC1

            // // Singleton
            // services.AddSingleton<IClassC, ClassC>();

            // // Transient 
            // services.AddTransient<IClassC, ClassC>();

            // // Scoped 
            // services.AddScoped<IClassC, ClassC>();

            // // Tạo đối tượng Proviedder
            // var provideder = services.BuildServiceProvider();

            // // Lấy ra đối tượng đã đăng ký
            // for(int i = 0; i < 5; i++) {
            //     var classc = provideder.GetService<IClassC>();
            //     Console.WriteLine(classc.GetHashCode());
            // }

            // using(var scope = provideder.CreateScope()) 
            // {
            //     var provideder1 = scope.ServiceProvider;
            //     // Lấy ra đối tượng đã đăng ký
            //     for(int i = 0; i < 5; i++) {
            //         var classc = provideder1.GetService<IClassC>();
            //         Console.WriteLine(classc.GetHashCode());
            //     }
            // }
            
            var services = new ServiceCollection();

            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<IClassB, ClassB2>(
                (provider) => {
                    var b2 = new ClassB2(
                        provider.GetService<IClassC>(),
                        "Thực hiện trong ClassB2"
                    );
                    return b2;
                }

            );
            services.AddSingleton<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();

            ClassA a = provider.GetService<ClassA>();
            a.CongViecA();
        }

    }
}
