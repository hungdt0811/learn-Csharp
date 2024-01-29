// See https://aka.ms/new-console-template for more information
Console.WriteLine("Cau truc du lieu Stack trong C#");
Console.WriteLine("-------------------------------");

Stack<string> hanghoa = new Stack<string>();

// them phan tu vao stack

hanghoa.Push("Mat hang 1");
hanghoa.Push("Mat hang 2");
hanghoa.Push("Mat hang 3");
hanghoa.Push("Mat hang 4");

foreach (var item in hanghoa)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------------------------------");

var mathang = hanghoa.Pop();
Console.WriteLine($"Boc do: {mathang}");

Console.WriteLine("-------------------------------");
foreach (var item in hanghoa)
{
    Console.WriteLine(item);
}

