// See https://aka.ms/new-console-template for more information
using ExtensionMethod;
using myLib;

Console.WriteLine("Extension Method (Phuong thuc mo rong)!");
Console.WriteLine("---------------------------------------");

string s = "Hello World";

//MyClass.Print(s, ConsoleColor.Red);
//MyClass.Print(s, ConsoleColor.Green);

s.Print(ConsoleColor.Yellow);
"Xin".Print(ConsoleColor.Blue);
"Chao".Print(ConsoleColor.Red);
"Cac".Print(ConsoleColor.Cyan);
"Ban".Print(ConsoleColor.Magenta);

Console.WriteLine("..........");

double a = 2.5;
Console.WriteLine(a.BinhPhuong());
Console.WriteLine(a.CanBachai());
Console.WriteLine(a.Sin());
Console.WriteLine(a.Cos());