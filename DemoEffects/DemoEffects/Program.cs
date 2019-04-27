using DemoEffects.Effects;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace DemoEffects
{
    class Program
    {
        static IEffect effectTopLeft = new LineEffect(false, 10, 10);
        static IEffect effectTopRight = new LineEffect(false, 10, 10);
        static IEffect effectBottomLeft = new LineEffect(false, 10, 10);
        static IEffect effectBottomRight = new LineEffect(false, 10, 10);

        public static RenderWindow app;

        public static Clock clock = new Clock();

        static Random random = new Random();
        static uint WINDOW_WIDTH = 255;
        static uint WINDOW_HEIGHT = 255;

        static void Main(string[] args)
        {
            Init();

        }

        public static float GetTime()
        {
            float returnValue = clock.ElapsedTime.AsSeconds();
            return returnValue;
        }
        
        public static void Init()
        {
            app = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Demo Effects");
            app.Closed += new EventHandler(OnClose);

            effectTopLeft = new Metablob((int)WINDOW_WIDTH / 2, (int)WINDOW_HEIGHT / 2);
            effectTopLeft.SetPosition(0, 0);

            effectTopRight = new CircleEffect((int)WINDOW_WIDTH / 2 + 1, (int)WINDOW_HEIGHT / 2);
            effectTopRight.SetPosition((int)WINDOW_WIDTH / 2, 0);

            effectBottomRight = new LineEffect(false, (int)WINDOW_WIDTH / 2 + 1, (int)WINDOW_HEIGHT / 2 + 1);
            effectBottomRight.SetPosition((int)WINDOW_WIDTH / 2, (int)WINDOW_HEIGHT / 2);

            effectBottomLeft = new PlasmaEffect((int)WINDOW_WIDTH / 2, (int)WINDOW_HEIGHT / 2 + 1);
            effectBottomLeft.SetPosition(0, (int)WINDOW_HEIGHT / 2);

            RectangleShape horLine = new RectangleShape(new SFML.System.Vector2f(WINDOW_WIDTH, 3));
            horLine.Position = new SFML.System.Vector2f(0, (WINDOW_HEIGHT / 2) - 1);
            horLine.FillColor = Color.Black;

            RectangleShape verLine = new RectangleShape(new SFML.System.Vector2f(3, WINDOW_HEIGHT));
            verLine.Position = new SFML.System.Vector2f((WINDOW_WIDTH/2)-1, 0);
            verLine.FillColor = Color.Black;

            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(Color.Red);

                effectTopLeft.DoEffect();
                effectTopRight.DoEffect();
                effectBottomLeft.DoEffect();
                effectBottomRight.DoEffect();

                app.Draw(effectTopLeft.GetCurrentFrame());
                app.Draw(effectTopRight.GetCurrentFrame());
                app.Draw(effectBottomLeft.GetCurrentFrame());
                app.Draw(effectBottomRight.GetCurrentFrame());

                app.Draw(horLine);
                app.Draw(verLine);


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
