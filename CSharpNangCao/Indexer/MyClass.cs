using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal class MyClass
    {

    }

    class Vector
    {
        double _x;
        double _y;

        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public void Info() => Console.WriteLine($"Toa do cua vector la: ({_x},{_y})");

        // vector + vector -> vector
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1._x + v2._x, v1._y + v2._y);
        }

        // indexer
        public double this[int i]
        {
            set { 
                switch (i)
                {
                    case 0:
                        _x = value;
                    break;
                    case 1:
                        _y = value;
                    break;
                    default:
                        throw new Exception("Chi so sai");
                    break;
                }
            }
            get {
                switch (i)
                {
                    case 0:
                        return _x;
                    case 1:
                        return _y;
                    default:
                        throw new Exception("Chi so sai");
                        break;
                }
            }
        }
    }
}
