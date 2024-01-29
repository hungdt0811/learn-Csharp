using System.Net.Http.Headers;
using System.Text;

namespace HttpClient_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Sử dụng HttpClient gửi truy vấn tới Http Server");
            Console.WriteLine("-----------------------------------------------");

            // var url = "https://google.com/search?q=xuanthulab";
            // var task = GetWebContent(url);
            // task.Wait(); // Đợi kết thúc của Task
            // string html = task.Result;
            // Console.WriteLine(html);

            var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
            var task = DownloadDataBytes(url);
            task.Wait();
            byte[] bytes = task.Result;

            // Console.WriteLine(bytes);

            // đặt tên file
            string filepath = "anh1.png";
            using (var stream = new FileStream (filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            stream.Write (bytes, 0, bytes.Length);

            var task2 = DownloadStream(url, "2.png");;
            task2.Wait();
            


        }

        // xây dựng phương thức trả về nội dung trang web
        public static async Task<string> GetWebContent(string url)
        {
            using var httpClient = new HttpClient(); // sử dụng using để đói tượng tự động hủy khi thoát khỏi phương thức
            try
            {
                // Thiết lập Headers
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/");
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                
                // Thực hiện truy vấn Get
                HttpResponseMessage httpResponseaMessage = await httpClient.GetAsync(url);
                // Lấy ra headers
                ShowHeaders(httpResponseaMessage.Headers);
                // Lấy ra nội dung content
                string html = await httpResponseaMessage.Content.ReadAsStringAsync();
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Lỗi";
            }   
        }
        // Phương thức hiển thị headers
        static void ShowHeaders(HttpResponseHeaders headers)
        {
            Console.WriteLine("Các Header:");
            foreach (var header in headers)
            {
                Console.WriteLine($"{header.Key} : {header.Value}");
            }
        }

        // Xây dựng phương thức download data 
        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            using var httpClient = new HttpClient(); // sử dụng using để đói tượng tự động hủy khi thoát khỏi phương thức
            try
            {                
                // Thực hiện truy vấn Get
                HttpResponseMessage httpResponseaMessage = await httpClient.GetAsync(url);
                // Lấy ra nội dung content
                var bytes = await httpResponseaMessage.Content.ReadAsByteArrayAsync();
                return bytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }   
        }

        // Xây dựng phương thức download data băng ReadAsStreamAsync
        public static async Task DownloadStream(string url, string filename)
        {
            HttpClient httpClient = new HttpClient();

            try {
                var httpResponseaMessage = await httpClient.GetAsync(url);

                // Tạo ra 1 Stream
                using var stream = await httpResponseaMessage.Content.ReadAsStreamAsync();

                using var streamWrite = File.OpenWrite(filename);

                // Khi ta có stream ta có thể đọc theo từng byte hay từng khối byte theo stream
                int SIZEBUFFER = 500; // 500 byte /  buffer
                var buffer = new byte[SIZEBUFFER];

                bool endRead = false;
                do {
                    int numBytes = await stream.ReadAsync(buffer, 0, SIZEBUFFER); // ReadAsync(buffer, index start, max size buffer)
                    if (numBytes == 0) {
                        endRead = true;
                    }
                    else {
                        await streamWrite.WriteAsync(buffer, 9, numBytes);
                    }
                }
                while(!endRead);
            }
            catch(Exception err) {
                Console.WriteLine(err.Message);
            }
        }
    }
}
