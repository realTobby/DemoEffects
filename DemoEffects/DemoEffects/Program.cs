using DemoEffects.Effects;
using SFML.Graphics;
using SFML.Window;
using System;

namespace DemoEffects
{
    class Program
    {
        static IEffect currentEffect = new LineEffect(false);
        static Random random = new Random();
        static uint WINDOW_WIDTH = 255;
        static uint WINDOW_HEIGHT = 255;

        static void Main(string[] args)
        {
            Init();

        }

        public static void Init()
        {
            int currentIndex = 0;

            RenderWindow app = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Demo Effects");
            app.Closed += new EventHandler(OnClose);

            currentEffect = new PlasmaEffect();
            Texture effectTexture = new Texture(WINDOW_WIDTH, WINDOW_HEIGHT);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(Color.Red);

                int someVal = 0;// random.Next(0, 100);
                if(someVal == 73)
                {
                    Console.WriteLine(currentIndex);
                    currentIndex++;
                    switch (currentIndex)
                    {
                        case 0:
                            currentEffect = new CircleEffect();
                            break;
                        case 1:
                            currentEffect = new ChessEffect();
                            break;
                        case 2:
                            currentEffect = new LineEffect(false);
                            break;
                        case 3:
                            currentEffect = new LineEffect(true);
                            break;
                        case 4:
                            currentEffect = new PlasmaEffect();
                            currentIndex = -1;
                            break;
                    }
                }
                
                currentEffect.DoEffect();

                effectTexture.Update(currentEffect.GetCurrentFrame());

                Sprite effectScreen = new Sprite(effectTexture);
                app.Draw(effectScreen);

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
