using SFML.Graphics;
using SFML.System;

namespace Game
{
    interface IComponent : Drawable
    {
        void Cleanup();

        void HandleEvents();

        void Update(Game game, Time dt);
    }
}
