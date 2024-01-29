// See https://aka.ms/new-console-template for more information
using Generic;

Console.WriteLine("Generic");
Console.WriteLine("-------");


int a = 5;
int b = 20;

Console.WriteLine($"a: {a}; b: {b}");
Class1.Swap(ref a, ref b);
Console.WriteLine($"a: {a}; b: {b}");

Product<int> product1 = new Product<int>();

product1.setID(20);
product1.PrintID();

Product<string> product2 = new Product<string>();

product2.setID("Test");
product2.PrintID();