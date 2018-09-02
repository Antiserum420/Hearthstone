using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Extensions;
using Utils;


namespace Game
{
    public sealed class PlayState : GameState
    {
        private static readonly Lazy<PlayState> lazy = new Lazy<PlayState>(() => new PlayState());

        public static PlayState Instance => lazy.Value;

        private static JoystickManager JoystickManager => JoystickManager.Instance;

        private IList<Player> _players;

        private const float CONTROLLER_MOVEMENT_THRESHOLD = 20f;

        private static readonly Vector2f _velocity = new Vector2f(200f, 200f);

        static PlayState()
        {

        }

        private PlayState()
        {
            _players = new List<Player>();
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
            foreach(var joystick in JoystickManager.Joysticks.OrderBy(j => j.JoystickId))
            {
                var joystickId = (int)joystick.JoystickId;
                if(_players.ElementAtOrDefault(joystickId) == null)
                {
                    var player = new Player();
                    player.Initialize(Game, joystick);
                    _players.Add(player);
                }              
            }
        }

        public override void Update(Time dt)
        {
            foreach(var player in _players)
            {
                var joystick = player.Joystick;

                if ((Math.Abs(joystick.LeftStick.X) > CONTROLLER_MOVEMENT_THRESHOLD || Math.Abs(joystick.LeftStick.Y) > CONTROLLER_MOVEMENT_THRESHOLD))
                {
                    var angle = MathUtility.VectorToAngle(joystick.LeftStick);
                    player.Rotation = angle;

                    var direction = joystick.LeftStick;

                    _velocity.Times(((float)Math.Pow(10f, dt.AsSeconds())));

                    player.Position = new Vector2f
                    {
                        X = player.Position.X + _velocity.X * direction.X * dt.AsSeconds(),
                        Y = player.Position.Y + _velocity.X * direction.Y * dt.AsSeconds()
                    };
                }
            }
        }

        public override void Draw()
        { 
            foreach(var player in _players)
            {
                Game.Window.Draw(player);
            }
        }
    }
}
