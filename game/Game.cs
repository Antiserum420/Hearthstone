using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using shared.Extensions;
using System.Threading;
using System;

namespace game
{
    public class Game : IGame
    {
        private const int WINDOW_WIDTH = 1920;
        private const int WINDOW_HEIGHT = 1080;

        private IList<GameState> _gameStates;
        private Clock _clock;

        public RenderWindow Window { get; set; }
        public bool Running { get; set; }
        public bool Paused { get; set; }
        
        public Game()
        {
            _gameStates = new List<GameState>();
            _clock = new Clock();

            Window = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Game", Styles.Default);
        }

        public void Initialize()
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
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                Window.Dispose();
            }
        }

        public void HandleEvents()
        {
            Window.DispatchEvents();

            if (_gameStates.Count > 0)
            {
                var time = _clock.Restart();
                _gameStates[_gameStates.Count - 1].HandleEvents(this);
            }
        }

        public void Update()
        {
            if(_gameStates.Count > 0)
            {
                var time = _clock.Restart();
                _gameStates[_gameStates.Count - 1].Update(this, time);
            }
        }

        public void Draw()
        {
            Window.Clear();

            if(_gameStates.Count > 0)
            {
                _gameStates[_gameStates.Count - 1].Draw(this);
            }

            Window.Display();
        }

        public void PushState(GameState gameState)
        {
            _gameStates.Add(gameState);
        }

        public void PopState()
        {
            if(_gameStates.Count > 0)
            {
                _gameStates.RemoveAt(_gameStates.Count - 1);
            }
        }

        public void ChangeState(GameState gameState)
        {
            PopState();
            PushState(gameState);
        }
    } 
}


