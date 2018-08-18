using Shared.Resources;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    public class Player : GameObject
    {
        private Texture _playerTexture;
        private Sprite _playerSprite;

        private const float CONTROLLER_DEADZONE = 0.3f;

        public Player()
        {
            _playerTexture = ResourceManager.Instance.GetTexture("player");
            _playerSprite = new Sprite(_playerTexture);
        }

        public override void Update(Time dt)
        {

        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

        }

        public override FloatRect GetGlobalBounds()
        {
            return new FloatRect();
        }
    }
}
