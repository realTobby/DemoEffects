using System;
using System.Collections.Generic;
using DemoEffects.Models;
using SFML.Graphics;

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

        public Image GetPixels()
        {
            Image resultImage = new Image(255, 255);
            foreach (var pixel in pixels)
            {
                resultImage.SetPixel((uint)pixel.positionX, (uint)pixel.positionY, pixel.GetColor());
            }

            return resultImage;
        }
    }
}
