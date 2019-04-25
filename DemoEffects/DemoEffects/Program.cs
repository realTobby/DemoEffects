using DemoEffects.Effects;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEffects
{
    class Program
    {
        static IEffect currentEffect = new LineEffect(false);

        static void Main(string[] args)
        {
            Init();

        }

        public static void Init()
        {
            RenderWindow app = new RenderWindow(new VideoMode(255, 255), "Demo Effects");
            app.Closed += new EventHandler(OnClose);

            currentEffect = new ChessEffect(255,255);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(Color.Black);

                currentEffect.DoEffect();
                var pixels = currentEffect.GetPixels();

                foreach(var pixel in pixels)
                {
                    byte[] values = BitConverter.GetBytes(pixel.color);
                    if (!BitConverter.IsLittleEndian) Array.Reverse(values);
                    RectangleShape newPixel = new RectangleShape(new SFML.System.Vector2f(1, 1));
                    newPixel.FillColor = new Color(values[2], values[1], values[0]);
                    newPixel.Position = new SFML.System.Vector2f(pixel.positionX, pixel.positionY);
                    app.Draw(newPixel);
                }
                // Update the window
                app.Display();
            }
        }

        private static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
    }
}
