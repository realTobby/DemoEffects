using SFML.Graphics;
using System;

namespace DemoEffects.Effects
{
    public class LineEffect : BaseEffect, IEffect
    {
        bool isSloped = false;
        float sineThreshhold = 0f;
        bool isForward = true;

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
                        color = (int)(128.0 + (128.0 * Math.Sin((x+y) / sineThreshhold)));
                    }
                    else
                    {
                        color = (int)(128.0 + (128.0 * Math.Sin(x / sineThreshhold)));
                    }

                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }

            if (isForward == true)
            {
                sineThreshhold += 0.05f;
            }
            else
            {
                sineThreshhold -= 0.05f;
            }

            if (sineThreshhold >= 16.0f)
            {
                isForward = false;
            }
            if (sineThreshhold <= -16.0f)
            {
                isForward = true;
            }

        }
    }
}
