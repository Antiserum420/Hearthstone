using SFML.Graphics;
using System;

namespace Game
{
    public interface IGame : IDisposable
    {
        RenderWindow Window { get; }

        bool Running { get; }

        bool Paused { get; }

        void Initialize();

        void HandleEvents();

        void Update();

        void Draw();

        void PushState(GameState gameState);

        void PopState();

        void ChangeState(GameState gameState);
    }
}
