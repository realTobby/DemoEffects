using DemoEffects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects.Effects
{
    public class LineEffect : IEffect
    {
        List<PixelPoint> pixels = new List<PixelPoint>();
        bool isSloped = false;
        float sineThreshhold = 8.0f;

        int w = 0;
        int h = 0;

        public LineEffect(int w, int h, bool isSloped)
        {
            this.w = w;
            this.h = h;
            pixels = new List<PixelPoint>();
            this.isSloped = isSloped;
        }

        public LineEffect(int w, int h)
        {
            this.w = w;
            this.h = h;
            pixels = new List<PixelPoint>();
        }


        public LineEffect()
        {
            pixels = new List<PixelPoint>();
        }

        public LineEffect(bool sloped)
        {
            isSloped = sloped;
        }

        public void DoEffect()
        {
            int h = 255;
            int w = 255;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int color = 1;
                    if(isSloped == true)
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin((x+y) / 8.0)));
                    }
                    else
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin(x / 8.0)));
                    }


                    PixelPoint newPixel = new PixelPoint(x, y, color);
                    pixels.Add(newPixel);
                }
            }

            sineThreshhold += 1.0f;
            if(sineThreshhold >= 8.0f)
            {
                sineThreshhold = 5.0f;
            }

        }

        public List<PixelPoint> GetPixels()
        {
            var resultPlasma = pixels;
            pixels = new List<PixelPoint>();

            return resultPlasma;
        }
    }
}
