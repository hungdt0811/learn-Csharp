// See https://aka.ms/new-console-template for more information
using ExceptionLession;
Console.WriteLine("Exception in C#!!!");
Console.WriteLine("------------------");

//int a = 5;
//int b = 0;

//try
//{
//    var c = a / b;
//    Console.WriteLine(c);
//    int[] i = { 1, 2 };
//    var x = i[5];

//    string path = "1.txt";
//    string s = File.ReadAllText(path);
//}
//catch(DivideByZeroException e)
//{
//    Console.WriteLine("Thong tin loi: " + e.Message);
//    Console.WriteLine("Vi tri loi: " + e.StackTrace);
//    Console.WriteLine("Thuoc Class: " + e.GetType().Name);
//}
//catch (IndexOutOfRangeException e)
//{
//    Console.WriteLine(e.Message);
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

//Console.WriteLine("------------------");
//Console.WriteLine("Ket thuc chuong trinh !!!");

try
{
    MProgram.Register(null, 20);    
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.GetType().Name);
}

