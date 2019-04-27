using SFML.Graphics;
using System;

namespace DemoEffects.Effects
{
    public class PlasmaEffect : BaseEffect, IEffect
    {
        Random random = new Random();
        float time = 0;
        public PlasmaEffect(int w, int h) : base(w, h)
        {
        }

        public void DoEffect()
        {
            time = Program.GetTime();
            for(float y = 0; y < base.EffectHeight; y++)
            {
                float dy = (y / base.EffectHeight) - 0.5f;

                for(float x = 0; x < base.EffectWidth; x++)
                {
                    float dx = (x / base.EffectWidth) - 0.5f;
                    double v = Math.Sin(dx * 10 + time);
                    double cx = dx + 0.5f * Math.Sin(time / 5);
                    double cy = dy + 0.5f * Math.Cos(time / 3);

                    v += Math.Sin(Math.Sqrt(50 * (cx * cx + cy * cy) + 1 + time));
                    v += Math.Cos(Math.Sqrt(dx * dx + dy * dy) - time);
                    double r = Math.Floor(Math.Sin(v * Math.PI) * 256);
                    double b = Math.Floor(Math.Cos(v * Math.PI) * 256);

                    var integerColor = Tools.RGBtoInt((int)r, (int)b, (int)b);

                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(integerColor));

                }
            }
            //time += 0.02f;
        }
    }
}
