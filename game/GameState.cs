using SFML.System;

namespace Game
{
    public abstract class GameState
    {
        protected IGame Game { get; private set; }

        public abstract void Cleanup();

        public virtual void Initialize(IGame game)
        {
            Game = game;
        }

        public abstract void HandleEvents();

        public abstract void Update(Time dt);

        public abstract void Draw();
    }
}
