// See https://aka.ms/new-console-template for more information
Console.WriteLine("Phương thức trong C#");
Console.WriteLine("--------------------");

PhuongThuc.MyMeThod myClass = new PhuongThuc.MyMeThod();
myClass.XinChao1();
Console.WriteLine(myClass.TinhTong1(1, 5));

PhuongThuc.MyMeThod.XinChao2();
Console.WriteLine(PhuongThuc.MyMeThod.TinhTong2(6, 3));


int a1 = 10;
int b1 = 5;

float a2 = 6;
float b2 = 5.6f;

double a3 = 6;
double b3 = 5.6;

Console.WriteLine(PhuongThuc.MyMeThod.Tich(a1, b1));
Console.WriteLine(PhuongThuc.MyMeThod.Tich(a2, b2));
Console.WriteLine(PhuongThuc.MyMeThod.Tich(a3, b3));

Console.WriteLine(PhuongThuc.MyMeThod.ConvertFullName("hung", "dang", "trong"));
Console.WriteLine(PhuongThuc.MyMeThod.ConvertFullName(ho: "dang", tenDem: "trong", ten: "hung"));
Console.WriteLine(PhuongThuc.MyMeThod.ConvertFullName(ten: "Hung"));

int x = 3;

PhuongThuc.MyMeThod.BinhPhuong(ref x);
Console.WriteLine(x);

int y;
PhuongThuc.MyMeThod.BinhPhuong(4, out y);
Console.WriteLine(y);

