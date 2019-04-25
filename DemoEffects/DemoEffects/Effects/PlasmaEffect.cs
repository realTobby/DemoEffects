using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects.Effects
{
    public class PlasmaEffect : BaseEffect, IEffect
    {
        int paletteShift;
        int[] colorPalette = new int[256];
        int w = 255;
        int h = 255;

        public PlasmaEffect()
        {
            for (int x = 0; x < 256; x++)
            {
                //use HSVtoRGB to vary the Hue of the color through the palette
                int r;
                int g;
                int b;
                Tools.HsvToRgb(x, 255, 255, out r, out g, out b);
                colorPalette[x] = Tools.RGBtoInt(r, g ,b);
            }

            //generate the plasma once
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    //the plasma buffer is a sum of sines
                    int color = (int)(128.0 + (128.0 * Math.Sin(x / 16.0)) + 128.0 + (128.0 * Math.Sin(y / 16.0))) / 2;
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }

        }


        public void DoEffect()
        {
            //the parameter to shift the palette varies with time
            paletteShift = (int)(DateTime.Now.Second / 10.0);

            //draw every pixel again, with the shifted palette color
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    var currentPixel = currentFrame.GetPixel((uint)x, (uint)y);
                    int rgb = Tools.RGBtoInt(currentPixel.R, currentPixel.G, currentPixel.B);

                    var color = colorPalette[(rgb + paletteShift) % 256];
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }
        }
    }
}
