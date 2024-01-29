using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Annotation_Attribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Data Annotation / Attribute!");
            Console.WriteLine("----------------------------");


            User user = new User()
            {
                name = "Abc",
                age = 10,
                email = "abc@gmail.com",
                phoneNumber = "034654132659847"
            };
            var result = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(user);    // Khởi tạo đội tượng validationContext
            bool kq = Validator.TryValidateObject(user, context, result, true);
            if (!kq) 
            {
                result.ToList().ForEach(err =>
                {
                    Console.WriteLine(err.MemberNames.First()); // Thuộc ính bị lỗi
                    Console.WriteLine(err.ErrorMessage);        // Tên lỗi
                });
            }
        }

        class User
        {
            [Required(ErrorMessage = "Trường này không được để trống")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên phải từ 3 - 50 ký tự")]
            public string name { get; set; }

            [Range(18, 80, ErrorMessage = "Tuổi từ 18 - 80")]
            public int age { get; set; }

            [EmailAddress(ErrorMessage = "Địa chỉ email sai cấu trúc")]
            public string email { get; set; }
            [Phone]
            public string phoneNumber { get; set; }

            public void PrintInfo() => Console.WriteLine(name);
        }
    }
}
