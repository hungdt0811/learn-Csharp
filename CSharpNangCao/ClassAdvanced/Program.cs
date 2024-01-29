// See https://aka.ms/new-console-template for more information
using ClassAdvanced;

Console.WriteLine("Mot so chu de nang cao cua class");
Console.WriteLine("--------------------------------");

// Qua tai toan tu
Vector v1 = new Vector(1, 5);
Vector v2 = new Vector(3, 4);

var v3 = v1 + v2;

v1.Info();
v2.Info();
v3.Info();

