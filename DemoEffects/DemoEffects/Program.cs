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
                app.Clear(Color.Blue);


                // effect code here




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
