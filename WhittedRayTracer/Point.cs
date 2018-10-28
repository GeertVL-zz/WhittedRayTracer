using System;

namespace WhittedRayTracer
{
    public class Point : Tuple
    {
        public Point(double x, double y, double z)
            : base(x, y, z, 1.0)
        {
        }

        public static Point operator +(Point a, Point b)
        {
            throw new ArithmeticException("Adding two points is not possible");
        }
        
        public static Point operator +(Point a, Vector b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
    }
}