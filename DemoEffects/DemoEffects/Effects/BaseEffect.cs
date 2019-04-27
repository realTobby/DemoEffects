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
        public int EffectWidth;
        public int EffectHeight;

        private int x;
        private int y;

        public Image currentFrame = new Image(0, 0);

        public void InitEffect(int w, int h)
        {
            EffectWidth = w;
            EffectHeight = h;
            currentFrame = new Image((uint)EffectWidth, (uint)EffectHeight);
        }

        public BaseEffect(int w, int h)
        {
            InitEffect(w, h);
        }

        public Sprite GetCurrentFrame()
        {
            Sprite resultFrame = new Sprite(new Texture(currentFrame));
            resultFrame.Position = new SFML.System.Vector2f(x, y);

            return resultFrame;
        }

        public Color GetColor(int color)
        {
            byte[] values = BitConverter.GetBytes(color);
            if (!BitConverter.IsLittleEndian) Array.Reverse(values);
            return new Color(values[2], values[1], values[0]);
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
