// See https://aka.ms/new-console-template for more information
Console.WriteLine("Queue trong C#!");
Console.WriteLine("---------------");

Queue<string> hoso = new Queue<string>();

// Them phan tu vao cuoi danh sach
hoso.Enqueue("Ho so 1");
hoso.Enqueue("Ho so 2");
hoso.Enqueue("Ho so 3");
hoso.Enqueue("Ho so 4");

// Loai bo di phan tu dau tien cua danh sach va tra ve phan tu do
var hs = hoso.Dequeue();

Console.WriteLine("Xu ly ho so " + hs);
Console.WriteLine("Con lai: " + hoso.Count);