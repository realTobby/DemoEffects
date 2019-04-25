using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects.Effects
{
    public class BaseEffect
    {
        public Image currentFrame = new Image(255, 255);

        public Image GetCurrentFrame()
        {
            return currentFrame;
        }

        public Color GetColor(int color)
        {
            byte[] values = BitConverter.GetBytes(color);
            if (!BitConverter.IsLittleEndian) Array.Reverse(values);
            return new Color(values[2], values[1], values[0]);
        }
    }
}
