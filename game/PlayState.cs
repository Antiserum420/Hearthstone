using SFML.System;
using System;

namespace game
{
    public sealed class PlayState : GameState
    {
        private static readonly Lazy<PlayState> lazy = new Lazy<PlayState>(() => new PlayState());

        static PlayState()
        {

        }

        private PlayState()
        {

        }

        public static PlayState Instance => lazy.Value;

        public override void HandleEvents(Game game)
        {
            base.HandleEvents(game);
        }

        public override void Update(Game game, Time dt)
        {
            base.Update(game, dt);
        }

        public override void Draw(Game game)
        {
            base.Draw(game);
        }
    }
}
