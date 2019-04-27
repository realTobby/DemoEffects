using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace DemoEffects.Effects
{
    public class ChessEffect : BaseEffect, IEffect
    {
        public ChessEffect(int w, int h) : base(w, h)
        {
        }

        public void DoEffect()
        {
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(x / 8.0f)) + 128.0 + (128.0 * Math.Sin(y / 8.0f))) / 2;
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                    
                }
            }
        }
    }
}
