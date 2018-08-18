using SFML.System;
using System;

namespace Game
{
    public sealed class PlayState : GameState
    {
        private static readonly Lazy<PlayState> lazy = new Lazy<PlayState>(() => new PlayState());

        public static PlayState Instance => lazy.Value;

        private Player _player;

        static PlayState()
        {

        }

        private PlayState()
        {
            _player = new Player();
        }

        public override void Initialize(IGame game)
        {
            base.Initialize(game);
        }

        public override void Cleanup()
        {

        }

        public override void HandleEvents()
        {

        }

        public override void Update(Time dt)
        {

        }

        public override void Draw()
        { 
            Game.Window.Draw(_player);
        }
    }
}
