using System.Text;

namespace TypeExample
{
    internal class Program
    {
        [Mota("Lớp chưa thông tin về user")]
        class User
        {
            [Mota("Tên người dùng")]
            public string name { get; set; }
            [Mota("Tuổi người dùng")]
            public int age { get; set; }
            [Mota("Địa chỉ email người dùng")]
            public string email { get; set; }
            [Mota("Số điện thoại")]
            public string phoneNumber { get; set; }

            [Obsolete("Phương thức này đã lỗi thời, cần thay bằng ShowInfo")]
            public void PrintInfo() => Console.WriteLine(name);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Type trong C#");
            Console.WriteLine("-----------------------------");

            User user = new User()
            {
                name = "Abc",
                age = 20,
                email = "abc@gmail.com",
                phoneNumber = "03132659847"
            };

            var properties = user.GetType().GetProperties();

            foreach (var property in properties)
            {
               foreach (var attribute in property.GetCustomAttributes(false))
                {
                    MotaAttribute mota = attribute as MotaAttribute;
                    if(mota != null)
                    {
                        var value = property.GetValue(user);
                        var name = property.Name;
                        Console.WriteLine($"({name}) - {mota.ThongTinChiTiet}: {value}");
                    }
                }

            }

            //user.PrintInfo();

            //int a;

            //Type t1 = typeof(int);
            //var t2 = typeof(string);
            //var t3 = typeof(Array);

            ////Console.WriteLine(t1);
            ////Console.WriteLine(t2);
            ////Console.WriteLine(t3);

            //int b = 1;
            //var t4 = b.GetType();

            //Console.WriteLine("Tên kiểu dữ liệu: " + t4.FullName);

            //int[] arr = { 1, 2, 3, 4 };
            //Type t5 = arr.GetType();

            //Console.WriteLine("Tên kiểu dữ liệu: " + t5.FullName);

            //Console.WriteLine("---Các thuộc tính---");
            //t5.GetProperties()
            //    .ToList()
            //    .ForEach(x =>
            //    {
            //        Console.WriteLine(x.Name);
            //    });

            //Console.WriteLine("---Các trường dữ liệu---");
            //t5.GetFields()
            //    .ToList()
            //    .ForEach(x =>
            //    {
            //        Console.WriteLine(x.Name);
            //    });

            //Console.WriteLine("---Các phương thức---");
            //t5.GetMethods()
            //    .ToList()
            //    .ForEach(x =>
            //    {
            //        Console.WriteLine(x.Name);
            //    });

        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // Thuộc tính mô tả nơi sử dụng (class, property, method,..)
        class MotaAttribute : Attribute
        { 
            public string ThongTinChiTiet { get; set; }

            public MotaAttribute(string _ThongTinChiTiet)
            {
                ThongTinChiTiet = _ThongTinChiTiet;
            }
        }
    }
}
