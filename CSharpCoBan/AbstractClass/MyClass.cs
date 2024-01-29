using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract internal class Animal
    {
        public string name {  get; set; }
        public int leg { get; set; } 

        public void Info() => Console.WriteLine("Name: " + name + " || " + "Leg: " + leg);

        public abstract void soChan();
    }


    class Dog : Animal 
    {
       public override void soChan() => Console.WriteLine($"Leg: {leg}"); 
    }
}
