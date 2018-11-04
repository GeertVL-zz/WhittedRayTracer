using System;

namespace WhittedRayTracer
{
    public class Tuple
    {
        private readonly (double x, double y, double z, double w) _tuple;
        
        public Tuple(double x, double y, double z, double w)
        {
            _tuple = (x: x, y: y, z: z, w: w);
        }

        public (double x, double y, double z, double w) Value
            => _tuple;

        public double X
            => _tuple.x;

        public double Y
            => _tuple.y;

        public double Z
            => _tuple.z;

        public double W
            => _tuple.w;        
        
        public override bool Equals(object obj)
        {
            if (!(obj is Tuple item))
            {
                return false;
            }

            return Equals(X, item.X)
                   && Equals(Y, item.Y)
                   && Equals(Z, item.Z)
                   && Equals(W, item.W);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode ^ 397) * X.GetHashCode();
                hashCode = (hashCode ^ 397) * Y.GetHashCode();
                hashCode = (hashCode ^ 397) * Z.GetHashCode();
                hashCode = (hashCode ^ 397) * W.GetHashCode();

                return hashCode;       
            }
        }

        public static Tuple operator +(Tuple a, Tuple b)
        {
            return new Tuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public static Tuple operator -(Tuple a, Tuple b)
        {
            return new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Tuple operator -(Tuple t)
        {
            return new Tuple(-t.X, -t.Y, -t.Z, -t.W);
        }

        public static Tuple operator *(Tuple a, double scalar)
        {
            return new Tuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
        }

        public static Tuple operator /(Tuple a, double scalar)
        {
            return new Tuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);
        }
    }
}