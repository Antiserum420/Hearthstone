using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Shared.Extensions;
using System;
using Shared.Resources;

namespace Game
{
    public class Game : GameBase
    {
        private const int WINDOW_WIDTH = 1920;
        private const int WINDOW_HEIGHT = 1080;

        public Game() : base(new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Game", Styles.Default))
        {          

        }

        public override void Initialize()
        {
            Running = true;
            Paused = false;

            var view = new View(((Vector2f)Window.Size).Times(0.5F), new Vector2f(Window.Size.X, Window.Size.Y));
            Window.SetView(view);
            Window.SetFramerateLimit(144);
            Window.SetVerticalSyncEnabled(false);
          
            Window.Closed += (sender, e) => 
            {
                var window = sender as RenderWindow;
                window.Close();

                Running = false;
            };

            JoystickManager.Instance.Initialize(this);
        }

        public override void Dispose()
        {
            base.Dispose();

            ResourceManager.Instance.Cleanup();

            GC.SuppressFinalize(this);
        }

        public override void HandleEvents()
        {
            Window.DispatchEvents();

            if (_gameStates.Count > 0)
            {
                var time = _clock.Restart();
                _gameStates[_gameStates.Count - 1].HandleEvents();
            }
        }

        public override void Update()
        {
            if(_gameStates.Count > 0)
            {
                var time = _clock.Restart();
                _gameStates[_gameStates.Count - 1].Update(time);
            }
        }

        public override void Draw()
        {
            Window.Clear();

            if(_gameStates.Count > 0)
            {
                _gameStates[_gameStates.Count - 1].Draw();
            }
 
            Window.Display();
        }
    } 
}


