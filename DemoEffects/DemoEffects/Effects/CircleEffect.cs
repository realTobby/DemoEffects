using System;

namespace DemoEffects.Effects
{
    public class CircleEffect : BaseEffect, IEffect
    {
        float effectTime;
        bool isForward = true;

        public CircleEffect(int w, int h) : base(w, h)
        {
        }

        public void DoEffect()
        {
            effectTime = Program.GetTime() / 5;
            for (int y = 0; y < base.EffectHeight; y++)
            {
                for (int x = 0; x < base.EffectWidth; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(Math.Sqrt((x - base.EffectWidth / 2.0) * (x - base.EffectWidth / 2.0) + (y - base.EffectHeight / 2.0) * (y - base.EffectHeight / 2.0)) / effectTime)));
                    currentFrame.SetPixel((uint)x, (uint)y, GetColor(color));
                }
            }
        }
    }
}
