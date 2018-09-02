using SFML.System;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Joystick
    {
        public uint JoystickId { get; set; }

        public bool RightTriggerPressed { get; set; }
        public bool LeftTriggerPressed { get; set; }

        public Vector2f LeftStick { get; set; }
        public Vector2f RightStick { get; set; }

        public IDictionary<JoystickButtonType, bool> ButtonsPressed { get; set; }
        public IDictionary<JoystickNumPadType, bool> NumPadsPressed { get; set; }       

        public Joystick()
        {
            LeftStick = new Vector2f(0f, 0f);
            RightStick = new Vector2f(0f, 0f);

            ButtonsPressed = new Dictionary<JoystickButtonType, bool>();
            NumPadsPressed = new Dictionary<JoystickNumPadType, bool>();            
        }

        public void Initialize(IGame game)
        {
            JoystickId = 0;

            RightTriggerPressed = false;
            LeftTriggerPressed = false;

            Enum.GetValues(typeof(JoystickButtonType))
                .Cast<JoystickButtonType>()
                .Where(e => e != JoystickButtonType.None)
                .ToList()
                .ForEach(e => ButtonsPressed.Add(e, false));

            Enum.GetValues(typeof(JoystickNumPadType))
                .Cast<JoystickNumPadType>()
                .Where(e => e != JoystickNumPadType.None)
                .ToList()
                .ForEach(e => NumPadsPressed.Add(e, false));
        }
        
        public bool IsButtonPressed(JoystickButtonType buttonType)
        {
            return ButtonsPressed[buttonType];
        }

        public bool IsNumPadPressed(JoystickNumPadType buttonType)
        {
            return NumPadsPressed[buttonType];
        }
    }
}
