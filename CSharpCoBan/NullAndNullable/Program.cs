// See https://aka.ms/new-console-template for more information
using NullAndNullable;

Console.WriteLine("Null và nullable");
Console.WriteLine("----------------");

Abc a = null;

//if(a != null)
//    a.XinChao();

a?.XinChao();

int? age;

age = 10;

if(age.HasValue)
{
    int _age = age.Value;
    Console.WriteLine(_age);
}
