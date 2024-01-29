// See https://aka.ms/new-console-template for more information
using AnonymousAndDynamic;
using System.Linq;

Console.WriteLine("Kiểu vô danh và Dynamic");
Console.WriteLine("-----------------------");

var sanpham = new
{
    ten = "samsung 10 plus",
    gia = 1000,
    namsx = 2018,
};

Console.WriteLine(sanpham.ten);
Console.WriteLine("-----------------------");



List<SinhVien> dssinhvien = new List<SinhVien>()
{
    new SinhVien() {HoTen = "Nam", NamSinh = 2000, NoiSinh="Hai Phong"},
    new SinhVien() {HoTen = "Long", NamSinh = 1998, NoiSinh="Ha Noi"},
    new SinhVien() {HoTen = "Quang", NamSinh = 1999, NoiSinh="Hai Duong"},
    new SinhVien() {HoTen = "Dung", NamSinh = 2001, NoiSinh="Nam Dinh"},
    new SinhVien() {HoTen = "Hiep", NamSinh = 1999, NoiSinh="Hai Duong"},
};

var ketqua = from sv in dssinhvien
             where sv.NamSinh <= 2000
             select new
             {
                 Ten = sv.HoTen,
                 NS = sv.NoiSinh,
             };

foreach(var sv in ketqua)
{
    Console.WriteLine(sv.Ten + " - " + sv.NS);
}

dynamic variable1;

var variable2 = 123;

