using System;

namespace DemoEffects.Effects
{
    public class CircleEffect : BaseEffect, IEffect
    {
        public CircleEffect(int w, int h) : base(w, h)
        {
        }

        public void DoEffect()
        {
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(Math.Sqrt((x - base.EffectWidth / 2.0) * (x - base.EffectWidth / 2.0) + (y - base.EffectHeight / 2.0) * (y - base.EffectHeight / 2.0)) / 8.0f)));
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }
        }
    }
}
