using System;
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
            foreach (var canvasPixel in canvas.Pixels)
            {
                Assert.True(canvasPixel == black);
            }
        }

        [Fact(DisplayName = "Writing pixels to a canvas")]
        public void WritingPixels()
        {
            var c = new Canvas(10, 20);
            var red = new Color(1, 0, 0);
            
            c.WritePixel(2, 3, red);
            
            Assert.Equal(red, c[2, 3]);
        }

        [Fact(DisplayName = "Constructing the PPM header")]
        public void ConstructingPPMHeader()
        {
            var c = new Canvas(5, 3);
            var ppm = c.ToPpm();

            var lines = ppm.Split('\n', StringSplitOptions.RemoveEmptyEntries);            
            Assert.Equal("P3", lines[0]);
            Assert.Equal("5 3", lines[1]);
            Assert.Equal("255", lines[2]);
        }

        [Fact(DisplayName = "Constructing the PPM pixel data")]
        public void ConstructingPPMPixelData()
        {
            var c = new Canvas(5, 3);
            var c1 = new Color(1.5, 0, 0);
            var c2 = new Color(0, 0.5, 0);
            var c3 = new Color(-0.5, 0, 1);
            
            c.WritePixel(0, 0, c1);
            c.WritePixel(2, 1, c2);
            c.WritePixel(4, 2, c3);

            var ppm = c.ToPpm();

            var lines = ppm.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", lines[3]);
            Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", lines[4]);
            Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", lines[5]);
        }

        [Fact(DisplayName = "Splitting long lines in PPM files")]
        public void SplittingPPMData()
        {
            var c = new Canvas(10, 2);

            for (int h = 0; h < c.Height; h++)
            {
                for (int w = 0; w < c.Width; w++)
                {
                    c.WritePixel(w, h, new Color(1, 0.8, 0.6));
                }
            }

            var ppm = c.ToPpm();

            var lines = ppm.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[3]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[4]);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[5]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[6]);
        }

        [Fact(DisplayName = "PPM files are terminated by a newline")]
        public void PpmTerminateWithNewline()
        {
            var c = new Canvas(5, 3);
            var ppm = c.ToPpm();
            
            Assert.Equal('\n', ppm[ppm.Length - 1]);
        }
    }
} 