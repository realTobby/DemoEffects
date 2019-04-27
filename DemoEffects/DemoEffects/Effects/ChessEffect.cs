using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace DemoEffects.Effects
{
    public class ChessEffect : BaseEffect, IEffect
    {
        float sineThreshhold = 0f;
        bool isForward = true;

        public ChessEffect(int w, int h) : base(w, h)
        {
        }

        public void DoEffect()
        {
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(x / sineThreshhold)) + 128.0 + (128.0 * Math.Sin(y / sineThreshhold))) / 2;
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
