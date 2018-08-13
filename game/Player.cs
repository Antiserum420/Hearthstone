using Shared.Resources;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    public class Player : IComponent
    {
        private Texture _playerTexture;
        private Sprite _playerSprite;

        private Transform _playerTransform;

        private const float CONTROLLER_DEADZONE = 0.3f;

        public Player()
        {
            _playerTexture = ResourceManager.Instance.GetTexture("player");
            _playerSprite = new Sprite(_playerTexture);
        }

        public void Cleanup()
        {

        }

        public void HandleEvents()
        {
        
        }

        public void Update(Game game, Time dt)
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_playerSprite, states);
        }
    }
}
