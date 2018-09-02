using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Enums;
using SFML.System;

namespace Game
{
    public sealed class JoystickManager
    {
        private static readonly Lazy<JoystickManager> lazy = new Lazy<JoystickManager>(() => new JoystickManager());

        public IList<Joystick> Joysticks;

        private IGame _game;

        private float CONTROLLER_DEADZONE = 0.3f;

        static JoystickManager()
        {

        }

        private JoystickManager()
        {
            Joysticks = new List<Joystick>();
        }

        public static JoystickManager Instance => lazy.Value;

        public void Initialize(IGame game)
        {
            _game = game;
            _game.Window.JoystickConnected += OnJoystickConnected;
            _game.Window.JoystickDisconnected += OnJoystickDisconnected;
            _game.Window.JoystickButtonPressed += OnJoystickButtonPressed;
            _game.Window.JoystickButtonReleased += OnJoystickButtonReleased;
            _game.Window.JoystickMoved += OnJoystickMoved;

            OnJoystickConnected(this, new JoystickConnectEventArgs(new JoystickConnectEvent { JoystickId = 0 }));
        }

        public void Update()
        {
            SFML.Window.Joystick.Update();
        }

        private void OnJoystickConnected(object sender, JoystickConnectEventArgs e)
        {
            var joystickId = e.JoystickId;

            if (!Joysticks.Any(j => j.JoystickId == joystickId))
            {
                var joystick = new Joystick
                {
                    JoystickId = joystickId
                };

                PushJoystick(joystick);
            }
        }

        private void OnJoystickDisconnected(object sender, JoystickConnectEventArgs e)
        {
            var joystickId = e.JoystickId;
            
            var joystick = Joysticks.FirstOrDefault(j => j.JoystickId == joystickId);
            if(joystick != null)
            {
                PopJoystick(joystick);
            }            
        }

        private void OnJoystickButtonPressed(object sender, JoystickButtonEventArgs e)
        {            
            var joystickId = e.JoystickId;
            var button = (JoystickButtonType)e.Button;

            var joystick = Joysticks.FirstOrDefault(j => j.JoystickId == joystickId);
            if(joystick != null)
            {
                joystick.ButtonsPressed[button] = true;
            }
        }

        private void OnJoystickButtonReleased(object sender, JoystickButtonEventArgs e)
        {
            var joystickId = e.JoystickId;
            var button = (JoystickButtonType)e.Button;

            var joystick = Joysticks.FirstOrDefault(j => j.JoystickId == joystickId);
            if (joystick != null)
            {
                joystick.ButtonsPressed[button] = false;
            }
        }

        private void OnJoystickMoved(object sender, JoystickMoveEventArgs e)
        {
            var joystickId = e.JoystickId;

            var joystick = Joysticks.FirstOrDefault(j => j.JoystickId == joystickId);
            if (joystick != null)
            {
                joystick.LeftStick = new Vector2f
                {
                    X = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.X),
                    Y = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.Y)
                };

                joystick.LeftStick = new Vector2f
                {
                    X = Math.Abs(joystick.LeftStick.X) < CONTROLLER_DEADZONE ? 0f : joystick.LeftStick.X,
                    Y = Math.Abs(joystick.LeftStick.Y) < CONTROLLER_DEADZONE ? 0f : joystick.LeftStick.Y
                };

                joystick.RightStick = new Vector2f
                {
                    X = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.U),
                    Y = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.R)
                };

                joystick.RightStick = new Vector2f
                {
                    X = Math.Abs(joystick.RightStick.X) < CONTROLLER_DEADZONE ? 0f : joystick.RightStick.X,
                    Y = Math.Abs(joystick.RightStick.Y) < CONTROLLER_DEADZONE ? 0f : joystick.RightStick.Y
                };

                joystick.RightTriggerPressed = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.Z) < -0.5F;
                joystick.LeftTriggerPressed = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.V) < -0.5F;

                joystick.NumPadsPressed[JoystickNumPadType.Left] = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.PovX) == -100;
                joystick.NumPadsPressed[JoystickNumPadType.Right] = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.PovX) == 100;
                joystick.NumPadsPressed[JoystickNumPadType.Up] = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.PovY) == 100;
                joystick.NumPadsPressed[JoystickNumPadType.Down] = SFML.Window.Joystick.GetAxisPosition(joystickId, SFML.Window.Joystick.Axis.PovY) == -100;
            }
        }

        private void PushJoystick(Joystick joystick)
        {
            joystick.Initialize(_game);
            Joysticks.Add(joystick);
        }

        private void PopJoystick(Joystick joystick)
        {
            if (Joysticks.Count > 0)
            {
                Joysticks.RemoveAt(Joysticks.Count - 1);
            }
        }
    }
}
