using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExample
{
    internal class LamViecVoiODia
    {
        public static void show()
        {
            DriveInfo drive = new DriveInfo("C");

            Console.WriteLine("Name: " + drive.Name);
            Console.WriteLine("Type: " + drive.DriveType);
            Console.WriteLine("Label: " + drive.VolumeLabel);
            Console.WriteLine("Format: " + drive.DriveFormat);
            Console.WriteLine("Size: " + drive.TotalSize);      // tinh theo byte
            Console.WriteLine("Free: " + drive.TotalFreeSpace);

            Console.WriteLine("-------------------------");

            // lay ra tat ca o dia trong may
            var drives = DriveInfo.GetDrives();
            foreach (var dr in drives)
            {
                Console.WriteLine("Name: " + dr.Name);
                Console.WriteLine("Type: " + dr.DriveType);
                Console.WriteLine("Label: " + dr.VolumeLabel);
                Console.WriteLine("Format: " + dr.DriveFormat);
                Console.WriteLine("Size: " + dr.TotalSize);      // tinh theo byte
                Console.WriteLine("Free: " + dr.TotalFreeSpace);
                Console.WriteLine("-------------------------");
            }
        }
    }

    internal class LamViecVoiThuMuc
    {
        public static void show()
        {
            string path = "abc";

            Console.WriteLine($"Thu muc hien tai: {Directory.GetCurrentDirectory()}");

            var folderInfo = Directory.CreateDirectory(path); // tao thu muc
            Console.WriteLine($"Tong tin folder: {folderInfo}");
            //Directory.Delete(path); // Xoa folder

            if (Directory.Exists(path))
            {
                Console.WriteLine($"{path} ton tai");
            }
            else
            {
                Console.WriteLine($"{path} khong ton tai");
            }
        }
    }

    internal class LamViecVoiDuongDan
    {
        public static void show()
        {

            var separactorChar = Path.DirectorySeparatorChar;
            Console.WriteLine("Ky tu phan cach trong duong dan la: " + separactorChar);

            // Ghep noi duong dan
            var path = Path.Combine("Dir1", "Dir2", "FileName.txt");

            //path = Path.ChangeExtension(path, )
        }
    }

    internal class LamViecVoiFile
    {
        public static void show()
        {
            string fileName = "abc.txt";
            string content = "Xin chao cac ban 2024";

            // Ghi file
            //File.WriteAllText(fileName, content);
            //File.AppendAllText(fileName, content);


            // Đọc file
            //string readContent = File.ReadAllText(fileName);
            //Console.WriteLine(readContent);

            // Doi ten file
            File.Move("abc.txt", "content.txt");
        }
    }
}
