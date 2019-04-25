using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEffects.Models;

namespace DemoEffects.Effects
{
    public class ChessEffect : IEffect
    {
        List<PixelPoint> pixels = new List<PixelPoint>();


        int w = 0;
        int h = 0;

        public ChessEffect(int w, int h)
        {
            this.w = w;
            this.h = h;
            pixels = new List<PixelPoint>();
        }

        public ChessEffect()
        {
            pixels = new List<PixelPoint>();
        }


        public void DoEffect()
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(x / 8.0)) + 128.0 + (128.0 * Math.Sin(y / 8.0))) / 2;
                    PixelPoint newPixel = new PixelPoint(x, y, color);
                    pixels.Add(newPixel);
                }
            }
        }

        public List<PixelPoint> GetPixels()
        {
            return pixels;
        }
    }
}
