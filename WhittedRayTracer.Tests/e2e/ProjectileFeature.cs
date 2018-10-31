using System.IO;
using WhittedRayTracer.Tests.Helpers;
using Xunit;

namespace WhittedRayTracer.Tests.e2e
{
    public class ProjectileFeature
    {
        [Fact(DisplayName = "Draw projectile path on canvas")]
        public void DrawProjectilePath()
        {
            var p = new Projectile
            {
                Position = new Point(0, 1, 0), 
                Velocity = new Vector(1, 1.8, 0).Normalize() * 11.25             
            };
            var gravity = new Vector(0, -0.1, 0);
            var wind = new Vector(-0.01, 0, 0);
            var w = new World { Gravity = gravity, Wind = wind };
            var c = new Canvas(900, 550);

            var tick = MotionHelper.Tick(w, p);
            while (tick.Position.X < c.Width && tick.Position.Y < c.Height && tick.Position.Y > 0)
            {
                c.WritePixel((int)tick.Position.X, c.Height - (int)tick.Position.Y, new Color(1, 0, 0));
                tick = MotionHelper.Tick(w, tick);
            }

            var ppm = c.ToPpm();
            File.WriteAllText(@"d:\zetes\projectile.ppm", ppm);
        }
    }
}