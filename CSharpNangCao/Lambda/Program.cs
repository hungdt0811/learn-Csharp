// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bieu Thuc lambda");
Console.WriteLine("----------------");



//Action<string> log = (string s) => Console.WriteLine(s);

//Action<string, int> log = (s, a) => Console.WriteLine(s);

Action<string> log = s => Console.WriteLine(s);

log?.Invoke("Xin chào");


//Action<string, string> log2 = (string a, string b) => Console.WriteLine(a + " " + b);

Action<string, string> log2 = (a, b) => Console.WriteLine(a + " " + b);

log2?.Invoke("Welcome", "Dang Trong Hung");


// lambda phuc tap

Action<string> welcome;

welcome = (s) =>
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Welcome " + s);
    Console.ResetColor();
};

welcome?.Invoke("World!!!");

// 

Func<int, int, int> tinhTong;

tinhTong = (a, b) =>
{
    int result = a + b;
    return result;
};;

Console.WriteLine("Tong 2 so la: " + tinhTong?.Invoke(5, 9));

// VD3:

int[] myArr = { 1, 5, 6, 98, 56, 48, 56, 23, 45, 9, 12 };

var kq = myArr.Select((num) =>
        {
            if(num%2 == 0)
            {
                return $"{num} la so chan";
            }
            else
            {
                return $"{num} la so le";
            }
        });

foreach (var r in kq)
{
    Console.WriteLine(r);
}// VD 4

myArr.ToList().ForEach(x =>
{
    if(x % 3 == 0)
    {
        Console.WriteLine($"{x} chia het cho 3");
    }
    else
    {
        Console.WriteLine($"{x} khong chia het cho 3");
    }
    
});

