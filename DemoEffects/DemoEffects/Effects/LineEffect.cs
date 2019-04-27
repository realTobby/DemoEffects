using SFML.Graphics;
using System;

namespace DemoEffects.Effects
{
    public class LineEffect : BaseEffect, IEffect
    {
        bool isSloped = false;

        float effectTime = 0;


        public LineEffect(bool sloped, int w, int h) : base(w, h)
        {
            isSloped = sloped;
        }

        public void DoEffect()
        {
            effectTime = Program.GetTime() / 5;
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = 1;
                    if(isSloped == true)
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin((x+y) / effectTime)));
                    }
                    else
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin(x / effectTime)));
                    }

                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }
        }
    }
}
