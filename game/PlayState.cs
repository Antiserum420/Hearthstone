using SFML.System;
using System;

namespace Game
{
    public sealed class PlayState : GameState
    {
        private static readonly Lazy<PlayState> lazy = new Lazy<PlayState>(() => new PlayState());

        private Player _player;

        static PlayState()
        {
            
        }

        private PlayState()
        {
            _player = new Player();
        }

        public static PlayState Instance => lazy.Value;

        public override void Cleanup()
        {
            base.Cleanup();

            _player.Cleanup();
        }

        public override void HandleEvents(Game game)
        {
            base.HandleEvents(game);

            _player.HandleEvents();
        }

        public override void Update(Game game, Time dt)
        {
            base.Update(game, dt);

            _player.Update(game, dt);
        }

        public override void Draw(Game game)
        {
            base.Draw(game);

            game.Window.Draw(_player);
        }
    }
}
