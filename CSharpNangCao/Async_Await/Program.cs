using System.Text;

namespace Async_Await
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Async - Await trong C#");
            Console.WriteLine("----------------------");

            //DoSomeThing(5, "Tác vụ 1", ConsoleColor.Red);
            //DoSomeThing(3, "Tác vụ 2", ConsoleColor.Green);
            //DoSomeThing(4, "Tác vụ 3", ConsoleColor.Blue);
            //Console.WriteLine("Hello World!!!");

            //Task t1 = new Task(Action);  // () => {}
            //Task t2 = new Task(Action<Object>, Object);  // (Object) => {}

            //Task t1 = new Task(() =>
            //{
            //    DoSomeThing(7, "Tác vụ T1", ConsoleColor.Red);
            //});

            //Task t2 = new Task((object ob) =>
            //{
            //    string taskName = ob.ToString();
            //    DoSomeThing(3, taskName, ConsoleColor.Green);

            //}, "Tác vụ T2");

            //t1.Start();
            //t2.Start();

            Task t1 = Task1();
            Task t2 = Task2();
            DoSomeThing(2, "Tác vụ T3", ConsoleColor.Blue);

            //t1.Wait();
            //t2.Wait();
            //Task.WaitAll(t1, t2);
            await t1;
            await t2;
            Console.WriteLine("Ấn phím bất kỳ để thoát: ");
            Console.ReadKey();
            Console.WriteLine("Kết thúc chương trình...");
            
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

        static async Task Task1()
        {
            Task t1 = new Task(() =>
            {
                DoSomeThing(7, "Tác vụ T1", ConsoleColor.Red);
            });
            t1.Start();

            await t1;

            Console.WriteLine("Do something!!!");
        }

        static async Task Task2()
        {
            Task t2 = new Task((object ob) =>
            {
                string taskName = ob.ToString();
                DoSomeThing(3, taskName, ConsoleColor.Green);

            }, "Tác vụ T2");
            t2.Start();

            await t2;

            Console.WriteLine("Do something!!!");
        }

        static async Task Abc()
        {
            
            Task task = new Task(() =>
            {
                // ... Các chỉ thị
            });

            task.Start();
            await task;

            // ... Các chỉ thị khi tác vụ hoàn thành
        }

    }
}
