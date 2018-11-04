using System.Dynamic;

namespace WhittedRayTracer
{
    public class Matrix
    {
        private readonly int _x;
        private readonly int _y;

        public Matrix(int x, int y)
        {
            _x = x;
            _y = y;
            All = new double[x, y];
        }

        public double this[int x, int y]
        {
            get => All[x, y];
            set => All[x, y] = value;
        }

        public double[,] All { get; set; }

        public int X
            => _x;

        public int Y
            => _y;
        
        public static Matrix Identity
            => new Matrix(4, 4)
            {
                All = new double[,] {{1,0,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,1}}
            };

        public Matrix Transpose()
        {
            var result = new Matrix(X, Y);
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    result[y, x] = this[x, y];
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix item))
            {
                return false;
            }

            if (All.Length != item.All.Length)
            {
                return false;
            }

            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    if (!FloatingPointHelper.NearlyEqual(this[x, y], item[x, y], FloatingPointHelper.Epsilon))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                for (int x = 0; x < _x; x++)
                {
                    for (int y = 0; y < _y; y++)
                    {
                        hashCode = (hashCode ^ 397) * this[x, y].GetHashCode();
                    }
                }

                return hashCode;
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            var m = new Matrix(a.X, a.Y);
            for (int x = 0; x < a.X; x++)
            {
                for (int y = 0; y < a.Y; y++)
                {
                    for (int i = 0; i < a.X; i++)
                    {
                        m[x, y] = m[x, y] + a[x, i] * b[i, y];
                    }
                }
            }

            return m;
        }

        public static Tuple operator *(Matrix a, Tuple b)
        {
            double[] res = new double[4];

            for (int i = 0; i < a.Y; i++)
            {
                res[i] = res[i] + a[i, 0] * b.X;
                res[i] = res[i] + a[i, 1] * b.Y;
                res[i] = res[i] + a[i, 2] * b.Z;
                res[i] = res[i] + a[i, 3] * b.W;
            }


            return new Tuple(res[0], res[1], res[2], res[3]);
        }
    }
}