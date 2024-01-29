// See https://aka.ms/new-console-template for more information
using MyNameSpace;
using TenVietTat = MyNameSpace.Abc;

using static System.Console;
using SanPham;

Console.WriteLine("Namespace");
Console.WriteLine("---------");

Product sp1 = new Product();
sp1.Name = "Samsung";
sp1.Price = 100;
sp1.Description = "Note10 Plus";

WriteLine(sp1.GetInfo());

sp1.factory = new Product.Factory();

sp1.factory.name = "Nha may phan bon";
sp1.factory.address = "Hai Phong";
WriteLine(sp1.getFactory());

//WriteLine("Test");

//Class1.XinChao();

//TenVietTat.Class1.XinChao();


