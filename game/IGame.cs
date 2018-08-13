using System;

namespace Game
{
    interface IGame : IDisposable
    {
        void Initialize();

        void HandleEvents();

        void Update();

        void Draw();
    }
}
