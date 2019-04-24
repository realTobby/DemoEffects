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
        static float sinu = 8.0f;

        static void Main(string[] args)
        {
            Init();

        }

        public static void Init()
        {
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "Demo Effects");
            app.Closed += new EventHandler(OnClose);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(Color.White);

                int h = 255;
                int w = 255;
                
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        int color = Convert.ToInt32((128.0 + (128.0 * Math.Sin((x+y) / sinu))));
                        RectangleShape pixelShape = new RectangleShape(new SFML.System.Vector2f(1, 1));

                        byte[] values = BitConverter.GetBytes(color);
                        if (!BitConverter.IsLittleEndian) Array.Reverse(values);

                        pixelShape.FillColor = new Color(values[2], values[1], values[0]);
                        pixelShape.Position = new SFML.System.Vector2f(x, y);
                        app.Draw(pixelShape);
                    }
                }

                sinu++;


                

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
