namespace ClassAdvanced
{
    internal class Room
    {
        public readonly string name;
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
    }
}

