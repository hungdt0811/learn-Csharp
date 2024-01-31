using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ADONET_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // string sqlStringConnection = "Data Source=localhost,1433; Initial Catalog=xtlab;User ID=sa;PWD=Password123"; // Chuoi ket noi

            var sqlstringBuilder = new SqlConnectionStringBuilder();
            // [key] = value
            sqlstringBuilder["Server"] = "localhost,1433";  // chỉ ra serrver
            sqlstringBuilder["Database"] = "xtlab";         // chỉ ra DB
            sqlstringBuilder["UID"] = "sa";                 // chỉ ra user id
            sqlstringBuilder["PWD"] = "Password123";        // chỉ ra password

            var sqlStringConnection = sqlstringBuilder.ToString();
            Console.WriteLine(sqlStringConnection); 

            using var connection = new SqlConnection(sqlStringConnection);   // Khoi tao doi tuong connection
            Console.WriteLine(connection.State);    // Kiểm tra trạng thái cổng kết nối
            connection.Open();  // Mở cổng kết nối tới server
            Console.WriteLine(connection.State);

            //... truy vấn
            using DbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT DanhmucID, TenDanhMuc, MoTa FROM Danhmuc WHERE DanhmucID >= @index";

            var index = new SqlParameter("@index", 5); // khai bao gia tri
            command.Parameters.Add(index);  // dua gia tri vao parameter
            index.Value = 2;    // thay index = 2


            // command.ExecuteReader();
            using var sqlReader = command.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(sqlReader);
            
            // if(sqlReader.HasRows) { // Kiem tra xem co dong du lieu nao tra ve hay khong
            //     while(sqlReader.Read()) {
            //         var id = sqlReader.GetInt32(0);
            //         var tenDanhMuc = sqlReader["TenDanhMuc"];
            //         var mota = sqlReader["Mota"];
            //         Console.WriteLine($"{id} - {tenDanhMuc} - {mota}");
            //     }
            // }
            // else {
            //     Console.WriteLine("Khong co du lieu tra ve");
            // }



            // command.ExecuteNonQuery();
            // command.ExecuteScalar();
            

            connection.Close(); // Đóng cổng kết nối

        }
    }
}
