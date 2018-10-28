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
    }
}