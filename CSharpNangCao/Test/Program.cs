// See https://aka.ms/new-console-template for more information
using Publisher;

Console.WriteLine("Event Test !");
Console.WriteLine("-----");

//

Chicken chicken = new Chicken();
Fammer fammer = new Fammer();
Dog dog = new Dog();

fammer.BatSuKien(chicken);
dog.BatSuKien(chicken);

chicken.danhthuc += () => Console.WriteLine("Ga thuc day");
chicken.gay();