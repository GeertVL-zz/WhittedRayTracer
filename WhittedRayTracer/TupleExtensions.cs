namespace WhittedRayTracer
{
    public static class TupleExtensions
    {
        public static bool IsAPoint(this (double x, double y, double z, double w) tuple)
        {
            return tuple.w == 1.0;
        }

        public static bool IsAVector(this (double x, double y, double z, double w) tuple)
        {
            return tuple.w == 0;
        }
    }
}