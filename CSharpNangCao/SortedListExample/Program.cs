// See https://aka.ms/new-console-template for more information
using SortedListExample;
Console.WriteLine("Sorted List!");
Console.WriteLine("------------");

SortedList<string, Product> products = new SortedList<string, Product>();

// Gan phan tu
products["sanpham1"] = new Product() { name = "Iphone X", price = 1000, origin = "Trung Quoc", id = 1 };
products["sanpham2"] = new Product() { name = "Iphone 14", price = 3000, origin = "Trung Quoc", id = 2 };
products["sanpham3"] = new Product() { name = "Samsung s23", price = 2000, origin = "Han Quoc", id = 3 };

// them phan tu
products.Add("sanpham4", new Product() { name = "Vsmart", price = 800, origin = "Viet Nam", id = 4 });

// doc phan tu
var p = products["sanpham3"];
Console.WriteLine(p.name);

// lay danh sach key va value
var keys = products.Keys;
var values = products.Values;

foreach(var key in keys)
{
    Console.WriteLine(key);
    Console.WriteLine(products[key].name);
}
Console.WriteLine("------------");

// lay ra phan tu la tung cap key value
foreach (KeyValuePair<string, Product> item in products)
{
    var key = item.Key;
    var val = item.Value;
    Console.WriteLine($"{key} - {val.name}");
}
