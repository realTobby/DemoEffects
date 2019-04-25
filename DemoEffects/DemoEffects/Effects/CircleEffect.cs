using System;

namespace DemoEffects.Effects
{
    public class CircleEffect : BaseEffect, IEffect
    {
        int w = 255;
        int h = 255;
        float sineThreshhold = 0f;
        bool isForward = true;


        public void DoEffect()
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int color = (int)(128.0 + (128.0 * Math.Sin(Math.Sqrt((x - w / 2.0) * (x - w / 2.0) + (y - h / 2.0) * (y - h / 2.0)) / sineThreshhold)));
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
