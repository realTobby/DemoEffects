using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects.Models
{
    public class PixelPoint
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int color { get; set; }

        public PixelPoint()
        {

        }

        public PixelPoint(int x, int y)
        {
            positionX = x;
            positionY = y;
        }

        public PixelPoint(int x, int y, int color)
        {
            positionX = x;
            positionY = y;
            this.color = color;
        }

        public Color GetColor()
        {
            byte[] values = BitConverter.GetBytes(this.color);
            if (!BitConverter.IsLittleEndian) Array.Reverse(values);          
            return new Color(values[2], values[1], values[0]);
        }

    }
}
