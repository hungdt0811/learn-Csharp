using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public delegate void SuKienNhapSo(int x);
    internal class UserInput
    {
        //public event SuKienNhapSo sukiennhapso;

        public event EventHandler sukiennhapso; // delegate void KIEU(object? sender, EventArgs arg)
        public void Input()
        {
            do
            {
                Console.Write("Hay nhap vao so nguyen: ");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);

                // viec goi cac phuong thuc duoc luu trong delegate tuong tu nhu viec phat su kien
                sukiennhapso?.Invoke(this, new DuLieuNhap(i));
            }
            while (true);
        }
    }

    class TinhCanBacHai
    {
        // phuong thuc dang ky su kien nhap so cua class UserInput
        public void sub(UserInput input) 
        {
            input.sukiennhapso += CanBacHai;
        }
        public void CanBacHai(object? sender, EventArgs e)
        {
            DuLieuNhap dulieunhap = (DuLieuNhap)e;
            int x = dulieunhap.data;
            Console.WriteLine($"Can bac hai cua {x} la: {Math.Sqrt(x)}");
        }
    }

    class TinhBinhPhuong
    {
        // phuong thuc dang ky su kien nhap so cua class UserInput
        public void sub(UserInput input)
        {
            input.sukiennhapso += BinhPhuong;
        }
        public void BinhPhuong(object? sender, EventArgs e)
        {
            DuLieuNhap dulieunhap = (DuLieuNhap)e;
            int x = dulieunhap.data;
            Console.WriteLine($"Binh phuong cua {x} la: {x * x}");
        }
    }

    class DuLieuNhap : EventArgs 
    {
        public int data {  get; set; }
        public DuLieuNhap(int x) => data = x;
    }
}
