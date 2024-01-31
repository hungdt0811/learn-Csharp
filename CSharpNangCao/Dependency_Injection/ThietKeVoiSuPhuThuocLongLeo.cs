using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    internal class Car
    {
        Horn horn {  get; set; }

        public Car(Horn horn)
        {
            this.horn = horn;
        }
        public void Beep() 
        {
            horn.Beep();
        }  
    }

    class Horn
    {
        int level = 0; // Do lon cua coi
        public Horn(int level) 
        {
            this.level = level;
        }
        public void Beep() => Console.WriteLine("Bepp, beep ,...");
    }
}
