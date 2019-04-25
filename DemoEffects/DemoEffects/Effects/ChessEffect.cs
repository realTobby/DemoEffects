using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace DemoEffects.Effects
{
    public class ChessEffect : BaseEffect, IEffect
    {
        float sineThreshhold = 0.5f;

        int w = 255;
        int h = 255;


        public void DoEffect()
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(x / sineThreshhold)) + 128.0 + (128.0 * Math.Sin(y / sineThreshhold))) / 2;
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                    
                }
            }
            sineThreshhold += 0.5f;
            if (sineThreshhold >= 8.0f)
            {
                sineThreshhold = 0.5f;
            }
        }
    }
}
