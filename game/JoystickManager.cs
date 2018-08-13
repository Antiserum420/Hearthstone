using SFML.System;
using SFML.Window;
using System;

namespace Game
{
    public sealed class JoystickManager
    {
        private static readonly Lazy<JoystickManager> lazy = new Lazy<JoystickManager>(() => new JoystickManager());

        private Vector2f _leftStick;
        private Vector2f _rightStick;

        private bool _rightTrigger;
        private bool _leftTrigger;

        public bool RightTrigger { get { return _rightTrigger; } private set { } }
        public bool LeftTrigger { get { return _leftTrigger; } private set { } }        

        public Vector2f LeftStick { get { return _leftStick; } private set { } }
        public Vector2f RightStick { get { return _rightStick; } private set { } }

        private const float CONTROLLER_DEADZONE = 0.3f;

        static JoystickManager()
        {

        }

        private JoystickManager()
        {
            LeftStick = new Vector2f(0F, 0F);
            RightStick = new Vector2f(0F, 0F);
        }

        public static JoystickManager Instance => lazy.Value;

        public void Initialize(Game game)
        {
            game.Window.JoystickConnected += OnJoystickConnected;
            game.Window.JoystickDisconnected += OnJoystickDisconnected;
            game.Window.JoystickButtonPressed += OnJoystickButtonPressed;
            game.Window.JoystickButtonReleased += OnJoystickButtonReleased;
        }

        private void OnJoystickConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Joystick connected");

        }

        private void OnJoystickDisconnected(object sender, EventArgs e)
        {
            Console.WriteLine("Joystick disconnected");

        }

        private void OnJoystickButtonPressed(object sender, EventArgs e)
        {
            Console.WriteLine("yoe");

        }

        private void OnJoystickButtonReleased(object sender, EventArgs e)
        {
            Console.WriteLine("yoe");

        }

        private void OnJoystickMoved(object sender, EventArgs e)
        {
            _leftStick.X = Joystick.GetAxisPosition(0, Joystick.Axis.X);
            _leftStick.Y = Joystick.GetAxisPosition(0, Joystick.Axis.Y);

            if (Math.Abs(LeftStick.X) < CONTROLLER_DEADZONE)
            {
                _leftStick.X = 0F;
            }
            if (Math.Abs(LeftStick.Y) < CONTROLLER_DEADZONE)
            {
                _leftStick.Y = 0F;
            }
            
            _rightStick.X = Joystick.GetAxisPosition(0, Joystick.Axis.U);
            _rightStick.Y = Joystick.GetAxisPosition(0, Joystick.Axis.R);

            if (Math.Abs(_rightStick.X) < CONTROLLER_DEADZONE)
            {
                _rightStick.X = 0F;
            }
            if (Math.Abs(_rightStick.Y) < CONTROLLER_DEADZONE)
            {
                _rightStick.Y = 0F;
            }

            _rightTrigger = Joystick.GetAxisPosition(0, Joystick.Axis.Z) < -0.5F;
            _leftTrigger = Joystick.GetAxisPosition(0, Joystick.Axis.V) < -0.5F;
        }
    }
}
