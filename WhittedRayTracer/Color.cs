namespace WhittedRayTracer
{
    public class Color
    {
        private readonly (double red, double green, double blue) _color;

        public Color(double red, double green, double blue)
        {
            _color = (red: red, green: green, blue: blue);
        }

        public double Red
            => _color.red;

        public double Green
            => _color.green;

        public double Blue
            => _color.blue;

        public override bool Equals(object obj)
        {
            var item = obj as Color;
            if (item == null)
            {
                return false;
            }

            return FloatingPointHelper.NearlyEqual(Red, item.Red, FloatingPointHelper.Epsilon)
                   && FloatingPointHelper.NearlyEqual(Green, item.Green, FloatingPointHelper.Epsilon)
                   && FloatingPointHelper.NearlyEqual(Blue, item.Blue, FloatingPointHelper.Epsilon);
        }       

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode ^ 397) * Red.GetHashCode();
                hashCode = (hashCode ^ 397) * Green.GetHashCode();
                hashCode = (hashCode ^ 397) * Blue.GetHashCode();

                return hashCode;
            }
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.Red + b.Red, a.Green + b.Green, a.Blue + b.Blue);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.Red - b.Red, a.Green - b.Green, a.Blue - b.Blue);
        }

        public static Color operator *(Color a, double scalar)
        {
            return new Color(a.Red * scalar, a.Green * scalar, a.Blue * scalar);
        }
        
        public static Color operator *(Color a, Color b)
        {
            return new Color(a.Red * b.Red, a.Green * b.Green, a.Blue * b.Blue);
        }
    }
}