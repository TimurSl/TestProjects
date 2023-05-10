using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace RotatingHelloWorldSfmlDotNetCoreCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWindow window = new MyWindow();
            window.Show();
        }
    }

    class MyWindow
    {
        private bool enabled = true;

        public void Show()
        {
            VideoMode mode = new VideoMode(250, 250);
            RenderWindow window = new RenderWindow(mode, "Circle");

            window.Closed += (obj, e) => { window.Close(); };
            window.KeyPressed +=
                (sender, e) =>
                {
                    Window window = (Window)sender;
                    if (e.Code == Keyboard.Key.Escape)
                    {
                        enabled = false;
                        window.Close();
                    }
                };
            
            CircleShape shape = new CircleShape(100);
            shape.FillColor = Color.White;
            shape.Origin = new Vector2f(shape.Radius, shape.Radius);
            shape.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);


            while (enabled)
            {
                window.DispatchEvents();
                window.Clear(Color.Green);
                window.Draw(shape);
                window.Display();
            }
        }
    }
}