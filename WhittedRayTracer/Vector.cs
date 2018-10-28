using System;

namespace WhittedRayTracer
{
    public class Vector : Tuple
    {
        public Vector(double x, double y, double z)
            : base(x, y, z, 0.0)
        {
            
        }

        public Vector(double x, double y, double z, double w)
            : base(x, y, z, w)
        {
        }

        public static Vector operator -(Vector v, Point p)
        {
            throw new ArithmeticException("A point cannot be subtracted from a vector");
        }
        
        public double Magnitude()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));
        }

        public Vector Normalize()
        {
            var magnitude = Magnitude();
            return new Vector(
                X / magnitude,
                Y / magnitude,
                Z / magnitude,
                W / magnitude);
        }

        public double Dot(Vector other)
        {
            return X * other.X + Y * other.Y + Z * other.Z + W * other.W;
        }

        public static Vector Cross(Vector a, Vector b)
        {
            return new Vector(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);
        }
        
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }
    }
}