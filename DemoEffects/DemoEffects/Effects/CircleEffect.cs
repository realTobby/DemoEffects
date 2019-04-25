using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEffects.Models;

namespace DemoEffects.Effects
{
    class CircleEffect : IEffect
    {
        List<PixelPoint> pixels = new List<PixelPoint>();
        int w = 0;
        int h = 0;

        public CircleEffect(int w, int h)
        {
            pixels = new List<PixelPoint>();
            this.w = w;
            this.h = h;
        }

        public CircleEffect()
        {
            pixels = new List<PixelPoint>();
        }

        public void DoEffect()
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(Math.Sqrt((x - w / 2.0) * (x - w / 2.0) + (y - h / 2.0) * (y - h / 2.0)) / 8.0)));

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
