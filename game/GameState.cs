using SFML.Graphics;
using SFML.System;

namespace Game
{
    public abstract class GameState
    {
        public virtual void Cleanup()
        {

        }

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
