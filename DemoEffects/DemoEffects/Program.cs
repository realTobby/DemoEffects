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

            currentEffect = new CircleEffect(255,255);

            

            Texture texture = new Texture(255, 255);
            


            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(Color.Red);


                currentEffect.DoEffect();

                texture.Update(currentEffect.GetPixels());

                Sprite test = new Sprite(texture);
                app.Draw(test);


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
