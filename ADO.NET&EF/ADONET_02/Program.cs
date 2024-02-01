using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADONET_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tao chuoi ket noi
            var sqlstringBuilder = new SqlConnectionStringBuilder();
            sqlstringBuilder["Server"] = "localhost,1433";  // chỉ ra serrver
            sqlstringBuilder["Database"] = "hungdt";         // chỉ ra DB
            sqlstringBuilder["UID"] = "sa";                 // chỉ ra user id
            sqlstringBuilder["PWD"] = "Password123";        // chỉ ra password
            var sqlStringConnection = sqlstringBuilder.ToString();

            using var connection = new SqlConnection(sqlStringConnection);
            connection.Open();

            #region DataSet
            // var dataSet = new DataSet();

            // var table = new DataTable("User");    // Khoi tao doi tuong DataTable
            // dataSet.Tables.Add(table);            // Them table vao DataSet

            // // Them cac cot du lieu
            // table.Columns.Add("STT");
            // table.Columns.Add("HoTen");
            // table.Columns.Add("Tuoi");

            // // Them cac dong du lieu
            // table.Rows.Add(1, "Nguyen Van A", 25);
            // table.Rows.Add(2, "Nguyen Van B", 24);
            // table.Rows.Add(3, "Nguyen Van C", 22);

            // ShowTable(table);
            #endregion

            #region DataAdapter
            var adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table","MyUserTable"); // Thêm MyUserTable vào adapter là bảng sẽ nhận ánh xạ
            // SelectCommand
            string sqlConnectString = "select * from dbo.[user]";
            adapter.SelectCommand = new SqlCommand(sqlConnectString, connection);
            // InsertCommand
            adapter.InsertCommand = new SqlCommand(
                "insert into dbo.[user] (id, name, gender) values (@id, @name, @gender)",
                 connection);
            adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 32, "id");
            adapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "name");
            adapter.InsertCommand.Parameters.Add("@gender", SqlDbType.VarChar, 6, "gender");
            // DeleteCommand
            adapter.DeleteCommand = new SqlCommand(
                "delete from dbo.[user] where id = @id",
                 connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            pr1.SourceColumn = "id";
            pr1.SourceVersion = DataRowVersion.Original;

            // UpdateCommand
            adapter.UpdateCommand = new SqlCommand(
                "update dbo.[user] set phone = @phone where id = @id",
                 connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            pr2.SourceColumn = "id";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@phone", SqlDbType.VarChar, 50, "phone");

            var dataSet = new DataSet();

            adapter.Fill(dataSet);  // Đổ dữ liệu vào dataSet

            // Lấy ra bảng
            DataTable table = dataSet.Tables["MyUserTable"];
            ShowTable(table);

            // // Thao tác với DataTable
            // // Chèn thêm dòng
            // var row = table.Rows.Add();
            // row["id"] = "20";
            // row["name"] = "Hoàng Thanh Tùng";
            // row["gender"] = "male";

            // Xóa dòng
            // var row14 = table.Rows[14]; // lấy ra dòng số 15
            // row14.Delete();

            // Chỉnh sửa dòng
            var r = table.Rows[13]; // Lấy ra dòng số 14
            r["phone"] = "031201002658";

            // Cập nhật lại nguồn dữ liệu
            adapter.Update(dataSet);
            
            #endregion

            connection.Close();
        }

        static void ShowTable(DataTable table)
        {
            Console.WriteLine($"Tên table là: {table.TableName}");
            foreach (DataColumn col in table.Columns)
            {
                Console.Write($"{col.ColumnName,15}");

            }
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    Console.Write($"{row[i],15}");
                }
                Console.WriteLine();
            }

        }
    }
}
