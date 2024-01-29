// See https://aka.ms/new-console-template for more information
using ListExample;

Console.WriteLine("Kieu du lieu List");
Console.WriteLine("-----------------");

List<int> ds1 = new List<int>();

ds1.Add(1);
ds1.Add(2);

ds1.AddRange(new int[] { 6, 7, 8, 9 });

int slpt = ds1.Count; // dem so phan tu

Console.WriteLine(slpt);
Console.WriteLine(ds1[3]);

List<int> ds2 = new List<int>() { 25, 68, 98, 63, 45, 21, 16, 33, 79, 59, 96, 25, 67, 98 };

//foreach (int i in ds2)
//{
//    Console.Write(i + " ");
//}
//Console.WriteLine();
//ds2.Remove(25);

//foreach (int i in ds2)
//{
//    Console.Write(i + " ");
//}

var n = ds2.Find((num) => num %2 == 0);
Console.WriteLine(n);
var a = ds2.FindAll((num) => num >= 50);


foreach (int i in a)
{
    Console.Write(i + " ");
}
Console.WriteLine();
Console.WriteLine("-------------------------");

List<Product> products = new List<Product>()
{
    new Product()
    {
        name = "Iphone X", price = 1000, origin = "Trung Quoc", id = 1
    },
    new Product()
    {
        name = "Iphone 14", price = 3000, origin = "Trung Quoc", id = 2
    },
    new Product()
    {
        name = "Samsung s23", price = 2000, origin = "My", id = 3
    },
    new Product()
    {
        name = "Vsmart", price = 800, origin = "Viet Nam", id = 4
    },
    new Product()
    {
        name = "Sony", price = 900, origin = "Nhat Ban", id = 5
    }
};

//var p = products.Find((pro) => pro.origin == "Trung Quoc");

//if(p != null)
//{
//    Console.WriteLine($"{p.name} || {p.price}");
//}

foreach (Product p in products)
{
    Console.WriteLine($"{p.name} -- {p.price} -- {p.origin}");
}

Console.WriteLine("-----------------");
products.Sort((p1, p2) =>
{
    if (p1.price == p2.price) return 0;
    if (p1.price < p2.price) return 1;
    return -1;
});


foreach (Product p in products)
{
    Console.WriteLine($"{p.name} -- {p.price} -- {p.origin}");
}


Console.WriteLine("-----------------");
Console.WriteLine("Ket thuc chuong trinh");