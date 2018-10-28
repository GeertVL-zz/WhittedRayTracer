namespace WhittedRayTracer.Tests.Helpers
{
    public class Projectile
    {
        public Point Position { get; set; }

        public Vector Velocity { get; set; }
    }

    public class World
    {
        public Vector Gravity { get; set; }

        public Vector Wind { get; set; }
    }

    public class MotionHelper
    {
        public static Projectile Tick(World world, Projectile projectile)
        {
            var position = projectile.Position + projectile.Velocity;
            var velocity = projectile.Velocity + world.Gravity + world.Wind;
            
            return new Projectile { Position = position, Velocity = velocity };
        }
    }
}