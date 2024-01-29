// See https://aka.ms/new-console-template for more information
Console.WriteLine("HashSet trong C#");
Console.WriteLine("----------------");


HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 5, 6, 7 };
HashSet<int> set2 = new HashSet<int>() { 6, 7, 8, 9, 3, 1 };

set1.UnionWith(set2);
//set1.IntersectWith(set2);

foreach (var item in set1)
{
    Console.WriteLine(item);
}