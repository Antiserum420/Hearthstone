using SFML.System;

namespace Game
{
    public class Joystick
    {
        public uint JoystickId { get; set; }

        public bool RightTrigger { get; set; }
        public bool LeftTrigger { get; set; }

        public Vector2f LeftStick { get; set; }
        public Vector2f RightStick { get; set; }

        public bool AButton { get; set; }
        public bool BButton { get; set; }
        public bool XButton { get; set; }
        public bool YButton { get; set; }
        public bool BackButton { get; set; }
        public bool StartButton { get; set; }

        public Joystick()
        {
            LeftStick = new Vector2f(0f, 0f);
            RightStick = new Vector2f(0f, 0f);
        }

        public void Initialize(IGame game)
        {
            JoystickId = 0;

            RightTrigger = false;
            LeftTrigger = false;

            AButton = false;
            BButton = false;
            XButton = false;
            YButton = false;
            BackButton = false;
            StartButton = false;
        }       
    }
}
