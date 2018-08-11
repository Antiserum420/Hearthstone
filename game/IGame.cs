using System;

namespace game
{
    interface IGame : IDisposable
    {
        void Initialize();

        void HandleEvents();

        void Update();

        void Draw();
    }
}
