using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Game
{
    public abstract class GameBase : IGame
    {
        protected IList<GameState> _gameStates;
        protected Clock _clock;

        public RenderWindow Window { get; private set; }
        public bool Running { get; protected set; }
        public bool Paused { get; protected set; }

        public GameBase(RenderWindow window)
        {
            Window = window;
            
            _gameStates = new List<GameState>();
            _clock = new Clock();           

        }

        public virtual void Dispose()
        {
            foreach (var gameState in _gameStates)
            {
                gameState.Cleanup();
            }

            Window.Dispose();
        }

        public abstract void Initialize();

        public abstract void HandleEvents();

        public abstract void Update();

        public abstract void Draw();

        public virtual void PushState(GameState gameState)
        {
            gameState.Initialize(this);
            _gameStates.Add(gameState);
        }

        public virtual void PopState()
        {
            if (_gameStates.Count > 0)
            {
                _gameStates.RemoveAt(_gameStates.Count - 1);
            }
        }

        public virtual void ChangeState(GameState gameState)
        {
            PopState();
            PushState(gameState);
        }
    }
}
