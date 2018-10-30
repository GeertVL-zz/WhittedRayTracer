using System.Linq;
using Xunit;

namespace WhittedRayTracer.Tests
{
    public class CanvasFeature
    {
        [Fact(DisplayName = "Creating a canvas")]
        public void CreatingCanvas()
        {
            var canvas = new Canvas(10, 20);
            
            Assert.Equal(10, canvas.Width);
            Assert.Equal(20, canvas.Height);

            var black = new Color(0, 0, 0);
            Assert.True(canvas.Pixels.All(p => p.Color.Equals(black)));
        }

        [Fact(DisplayName = "Writing pixels to a canvas")]
        public void WritingPixels()
        {
            var c = new Canvas(10, 20);
            var red = new Color(1, 0, 0);
            
            c.WritePixel(2, 3, red);
            
            Assert.Equal(red, c[2, 3].Color);
        }
    }
} 