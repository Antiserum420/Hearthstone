using System;
using SFML.Graphics;
using SFML.Window;

namespace Hearthstone420
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            // app.Closed += new EventHandler(OnClose);

            Color windowColor = new Color(0, 192, 255);

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                // Clear screen
                app.Clear(windowColor);

                // Update the window
                app.Display();
            }
        }
    }
}
