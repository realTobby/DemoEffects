using SFML.Graphics;
using System;

namespace DemoEffects.Effects
{
    public class LineEffect : BaseEffect, IEffect
    {
        bool isSloped = false;
        public LineEffect(bool sloped, int w, int h) : base(w, h)
        {
            isSloped = sloped;
        }

        public void DoEffect()
        {
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = 1;
                    if(isSloped == true)
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin((x+y) / 8.0f)));
                    }
                    else
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin(x / 8.0f)));
                    }

                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }
        }
    }
}
