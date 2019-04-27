using DemoEffects.Effects;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace DemoEffects
{
    class Program
    {
        static IEffect currentEffect = new LineEffect(false, 10, 10);

        public static RenderWindow app;

        public static Clock clock = new Clock();

        static Random random = new Random();
        static int WINDOW_WIDTH = 255;
        static int WINDOW_HEIGHT = 255;

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
            currentEffect.SetPosition(0, 0);

            app = new RenderWindow(new VideoMode((uint)WINDOW_WIDTH, (uint)WINDOW_HEIGHT), "Demo Effects");
            app.Closed += new EventHandler(OnClose);

            int currentEffectIndex = 0;
            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(Color.Red);


                switch(currentEffectIndex)
                {
                    case 0:
                        currentEffect = new LineEffect(false, WINDOW_WIDTH, WINDOW_HEIGHT);
                        break;
                    case 1:
                        currentEffect = new CircleEffect(WINDOW_WIDTH, WINDOW_HEIGHT);
                        break;
                    case 2:
                        currentEffect = new PlasmaEffect(WINDOW_WIDTH, WINDOW_HEIGHT);
                        break;
                    case 3:
                        currentEffect = new ChessEffect(WINDOW_WIDTH, WINDOW_HEIGHT);
                        break;
                    case 4:
                        currentEffect = new LineEffect(true, WINDOW_WIDTH, WINDOW_HEIGHT);
                        break;
                }

                int someVal = random.Next(0, 100);
                if(someVal == 73)
                    currentEffectIndex++;
                if (currentEffectIndex >= 5)
                    currentEffectIndex = 0;


                currentEffect.DoEffect();
                app.Draw(currentEffect.GetCurrentFrame());

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

