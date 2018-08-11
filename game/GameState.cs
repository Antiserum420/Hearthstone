using SFML.System;

namespace game
{
    public abstract class GameState
    {
        public virtual void HandleEvents(Game game)
        {

        }

        public virtual void Update(Game game, Time dt)
        {
            
        }

        public virtual void Draw(Game game)
        {

        }
    }
}
