using System.Collections.Generic;
using System.Linq;

namespace WhittedRayTracer
{
    public class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
    }
    
    public class Canvas
    {
        private readonly List<Pixel> _pixels = new List<Pixel>();
        
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height; 
            Initialize();
        }
                       
        public int Width { get; }     
        public int Height { get; }

        public IEnumerable<Pixel> Pixels
            => _pixels;

        public void Initialize()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    _pixels.Add(new Pixel
                    {
                        X = x,
                        Y = y,
                        Color = new Color(0, 0, 0)
                    });
                }
            }
        }

        public void WritePixel(int x, int y, Color color)
        {
            var pixel = _pixels.First(p => p.X == x && p.Y == y);
            pixel.Color = color;
        }
        
        public Pixel this[int x, int y]
        {
            get { return _pixels.Find(p => p.X == x && p.Y == y); }
        }
    }
}