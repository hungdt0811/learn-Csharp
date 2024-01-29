// See https://aka.ms/new-console-template for more information
using Indexer;

Console.WriteLine("Indexer!!");
Console.WriteLine("---------");

// Indexer

Vector v1 = new Vector(5, 7);
Vector v2 = new Vector(2, 1);

// v1[0] -> toa do x1
// v1[1] -> toa do y1

// v1["ToaDoX"] -> toa do x1
// v1["ToaDoY"] -> toa do y1

v1.Info();
v1[0] = 10;
v1.Info();