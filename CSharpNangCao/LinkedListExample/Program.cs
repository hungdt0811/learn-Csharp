// See https://aka.ms/new-console-template for more information
Console.WriteLine("LinkedList trogn C#!");
Console.WriteLine("--------------------");


// Khoi tao
LinkedList<string> lessons = new LinkedList<string>();

// them phan tu vao ds
var node1 = lessons.AddFirst("Bai hoc 1");
var node3 = lessons.AddLast("Bai hoc 3");

LinkedListNode<string> node2 = lessons.AddAfter(node1,"Bai hoc 2");
var node4 = lessons.AddLast("Bai hoc 4");
var node5 = lessons.AddLast("Bai hoc 5");

// duyet danh sach
foreach (var item in lessons) 
{
    Console.WriteLine(item);
}

// truy cap node lien ke

var node = node3;
Console.WriteLine("Node hien tai: " + node.Value);

node = node.Next;
Console.WriteLine("Node lien sau: " + node.Value);

node = node.Previous;
Console.WriteLine("Node lien truoc: " + node.Value);
