// See https://aka.ms/new-console-template for more information
using Delegate;

Console.WriteLine("Delegate");

//ShowLog log = null;

//log += MyClass.Info;
//log += MyClass.Info;
//log += MyClass.Info;
//log += MyClass.Warning;
//log += MyClass.Warning;
//log += MyClass.Info;

//log?.Invoke("Hùng");


// Action, Func : delegate - gereric

//Action action;                  // tương đương với delegate void <delegate name>()
//Action<string, int> action1;    // tương đương với delegate void <delegate name>(string s, int i)

//Action<string> action2;

//action2 = MyClass.Info;
//action2 += MyClass.Warning;

//action2?.Invoke("Hello");

//// Func<return type, data type param,...> <delagate name;

//Func<int, int, int> f1;

//f1 = MyClass.Sum;


//var result = f1?.Invoke(2, 3);

//Console.WriteLine(result);

//Func<string, int, int, string> f2;

//f2 = MyClass.ShowCal;

//Console.WriteLine(f2?.Invoke("tổng", 5, 10));
//Console.WriteLine(f2?.Invoke("tích", 5, 10));

void Tong(int a, int b, ShowLog log)
{
    int result = a + b;
    log?.Invoke($"Ket qua la: {result}");
}

Tong(4, 5, MyClass.Info);
Tong(8, 8, MyClass.Warning);

