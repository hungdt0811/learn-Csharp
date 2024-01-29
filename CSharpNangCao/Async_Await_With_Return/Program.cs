using System.Text;

namespace Async_Await_With_Return
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Async - Await có trả về");
            Console.WriteLine("-----------------------");

            var task = GetWeb("https://theladuoc.edu.vn/");
            var content = await task;

            Console.WriteLine(content);

            // Task<string> t1 = new Task<string>(Func<string>) // () => {return string}
            // Task<string> t2 = new Task<string>(Func<object, string>) // (object ob) => {return string}

            //Task<string> t1 = new Task<string> (
            //    () => {
            //        DoSomeThing(8, "Tác vụ T1", ConsoleColor.Magenta);
            //        return "Retunr from T1";
            //    }
            //);

            //Task<string> t2 = new Task<string>(
            //    (Object ob) => {
            //        string t = ob.ToString();
            //        DoSomeThing(4, $"Tác vụ {t}", ConsoleColor.Yellow);
            //        return $"Retunr from {t}";
            //    }, "T2"
            //);

            //Task<string> t1 = Task1();
            //Task<string> t2 = Task2();

            ////t1.Start ();
            ////t2.Start ();

            //Task.WaitAll( t1 , t2 );

            //var kq1 = t1.Result;
            //var kq2 = t2.Result;
            //Console.WriteLine ( kq1 );
            //Console.WriteLine ( kq2 );

            //Console.WriteLine("Ấn phím bất kỳ để thoát: ");
            //Console.ReadKey();
            //Console.WriteLine("Kết thúc chương trình...");



        }

        static void DoSomeThing(int seconds, string message, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{message} running...");
                Console.ResetColor();
            }

            for (int i = 1; i <= seconds; i++)
            {
                Thread.Sleep(1000);
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{message} {i}");
                    Console.ResetColor();
                }
            }

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{message} Finish...");
                Console.ResetColor();
            }
        }

        static async Task<string> Task1()
        {
            Task<string> t1 = new Task<string>(
                () => {
                    DoSomeThing(8, "Tác vụ T1", ConsoleColor.Magenta);
                    return "Return from T1";
                }
            );
            t1.Start();
            var kq = await t1; // kết quả nhận được khi t1 hoàn thành

            Console.WriteLine("Tác vụ T1 đã hoàn thành...");

            return kq;
        }

        static async Task<string> Task2()
        {
            Task<string> t2 = new Task<string>(
                (Object ob) => {
                    string t = ob.ToString();
                    DoSomeThing(4, $"Tác vụ {t}", ConsoleColor.Yellow);
                    return $"Return from {t}";
                }, "T2"
            );
            t2.Start();
            var kq = await t2; // kết quả nhận được khi t2 hoàn thành

            Console.WriteLine("Tác vụ T1 đã hoàn thành...");

            return t2.Result;
        }

        static async Task<string> GetWeb(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage kq = await httpClient.GetAsync(url);    // đây là phương thức bất đồng bộ
            string content = await kq.Content.ReadAsStringAsync();      // đây là phương thức bất đồng bộ
            return content;
        }   


        //static async Task<Kiểu trả về> Abc()
        //{
        //    Task<Kiểu trả về> task = new Task<Kiểu trả về>(
        //        () =>
        //        {
        //            // ... các tác vụ
        //            return 
        //        }    
        //    )
        //    task.Start();
        //    var kq = await
        //    // ... Tác vụ sau khi task hoàn thành
        //    return kq;
        //}
    }
}
