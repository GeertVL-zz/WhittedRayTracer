using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

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
        private readonly Color[,] _pixels;
        
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height; 
            _pixels = new Color[Width, Height];
            Initialize();
        }
                       
        public int Width { get; }     
        public int Height { get; }

        public Color[,] Pixels
            => _pixels;

        private void Initialize()
        {
            var black = new Color(0, 0, 0);
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    _pixels[x, y] = black;
                }
            }
        }

        public void WritePixel(int x, int y, Color color)
        {
            if (x > Width)
            {
                throw new Exception($"Writing pixel x: {x} is not possible");
            }

            if (y > Height)
            {
                throw new Exception($"Writing pixel y: {y} is not possible");
            }
            
            _pixels[x, y] = color;
        }
        
        public Color this[int x, int y] => _pixels[x, y];

        public string ToPpm()
        {
            const int maxValue = 255;
            
            var header = $"P3\n{Width} {Height}\n{maxValue}\n";

            var content = new StringBuilder();
            content.Append(header);
            
            for (int y = 0; y < Height; y++)
            {
                var line = new StringBuilder();
                for (int x = 0; x < Width; x++)
                {
                    var color = this[x, y];
                    Normalize(line, CalculateColorValue(color.Red, maxValue));
                    Normalize(line, CalculateColorValue(color.Green, maxValue));
                    Normalize(line, CalculateColorValue(color.Blue, maxValue));
                    // line.Append($"{CalculateColorValue(this[x, y].Red, maxValue)} {CalculateColorValue(this[x, y].Green, maxValue)} {CalculateColorValue(this[x, y].Blue, maxValue)} ");
                }

                content.Append($"{line.ToString().Trim()}\n");
            }

            return content.ToString();
        }

        private int CalculateColorValue(double color, int maxValue)
        {
            if (color == 0)
            {
                return 0;
            }
            
            double colorValue = color * (maxValue + 1);
            if (colorValue >= maxValue)
            {
                return maxValue;
            }

            return colorValue <= 0 ? 0 : (int)Math.Floor(colorValue);
        }

        private void Normalize(StringBuilder line, double colorValue)
        {
            int lastLine = line.ToString().LastIndexOf('\n');
            if (lastLine == -1)
            {
                lastLine = 0;
            }

            if (line.Length == 0)
            {
                line.Append($"{colorValue}");
            }
            else
            {
                int newLength = line.Length - lastLine + 1 + colorValue.ToString().Length;
                line.Append(newLength > 70 ? $"\n{colorValue}" : $" {colorValue}");
            }
        }
    }
}