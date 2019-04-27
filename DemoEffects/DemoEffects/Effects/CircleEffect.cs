using System;

namespace DemoEffects.Effects
{
    public class CircleEffect : BaseEffect, IEffect
    {
        float sineThreshhold = 0f;
        bool isForward = true;

        public CircleEffect(int w, int h) : base(w, h)
        {
        }

        public void DoEffect()
        {
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(Math.Sqrt((x - base.EffectWidth / 2.0) * (x - base.EffectWidth / 2.0) + (y - base.EffectHeight / 2.0) * (y - base.EffectHeight / 2.0)) / sineThreshhold)));
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }
            if(isForward == true)
            {
                sineThreshhold += 0.2f;
            }else
            {
                sineThreshhold -= 0.2f;
            }

            if (sineThreshhold >= 16.0f)
            {
                isForward = false;
            }

            if(sineThreshhold <= -32.0f)
            {
                isForward = true;
            }

        }


    }
}
