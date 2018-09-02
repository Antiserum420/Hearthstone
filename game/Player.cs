using Shared.Resources;
using SFML.Graphics;
using SFML.System;
using Utils;

namespace Game
{
    public class Player : GameObject
    {
        private Texture _playerTexture;
        private Sprite _playerSprite;

        private IGame _game;
        public Joystick Joystick { get; private set; }        

        public Player()
        {
            _playerTexture = ResourceManager.Instance.GetTexture("player");
            _playerSprite = new Sprite(_playerTexture);
        }

        public void Initialize(IGame game, Joystick joystick)
        {
            _game = game;
            Joystick = joystick;
            MathUtility.CenterSprite(_playerSprite);
        }

        public override void Update(Time dt)
        {
            Transform.Translate(100f, 100f);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = Transform;            
            target.Draw(_playerSprite, states);
        }

        public override FloatRect GetGlobalBounds()
        {
            return new FloatRect();
        }
    }
}
