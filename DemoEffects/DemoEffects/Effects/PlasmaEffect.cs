using SFML.Graphics;
using System;

namespace DemoEffects.Effects
{
    public class PlasmaEffect : BaseEffect, IEffect
    {
        int w = 255;
        int h = 255;

        public void DoEffect()
        {
            int time = DateTime.Now.Millisecond / 500;

            for(float y = 0; y < h; y++)
            {
                float dy = (y / h) - 0.5f;

                for(float x = 0; x < w; x++)
                {
                    float dx = (y / w) - 0.5f;
                    double v = Math.Sin(dx * 10 + time);
                    double cx = dx + 0.5f * Math.Sin(time / 5);
                    double cy = dy + 0.5f * Math.Cos(time / 3);

                    v += Math.Sin(Math.Sqrt(50 * (cx * cx + cy * cy) + 1 + time));
                    v += Math.Cos(Math.Sqrt(dx * dx + dy * dy) - time);
                    double r = Math.Floor(Math.Sin(v * Math.PI) * 255);
                    double b = Math.Floor(Math.Cos(v * Math.PI) * 255);

                    var integerColor = Tools.RGBtoInt((int)r, (int)b, (int)b);

                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(integerColor));

                }
            }

        }
    }
}
