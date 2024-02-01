using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADONET_01_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var sqlStringBuilder = new SqlConnectionStringBuilder();

            sqlStringBuilder["Server"] = "localhost,1433";  // chỉ ra serrver
            sqlStringBuilder["Database"] = "hungdt";         // chỉ ra DB
            sqlStringBuilder["UID"] = "sa";                 // chỉ ra user id
            sqlStringBuilder["PWD"] = "Password123";        // chỉ ra password

            var sqlStringConnection = sqlStringBuilder.ToString();

            using var connection = new SqlConnection(sqlStringConnection);

            connection.Open();

            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "getUserInfo";               // Truy vấn là tên StoredProcedure
            command.CommandType = CommandType.StoredProcedure; // Thiết lập kiểu của truy vấn là Stored Procedure

            var id = new SqlParameter("@id", 0);
            command.Parameters.Add(id);

            id.Value = 1;

            var reader = command.ExecuteReader();
            if(reader.HasRows) {
                reader.Read();
                var name = reader["name"];
                var position = reader["position"];
                Console.WriteLine($"{name} - {position}");
            }

            connection.Close();
        }
    }
}
