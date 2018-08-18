using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    public abstract class GameObject : Transformable, Drawable
    {
        protected Vector2f Velocity { get; set; }

        public GameObject()
        {

        }

        public abstract void Update(Time dt);

        public abstract void Draw(RenderTarget target, RenderStates states);

        public abstract FloatRect GetGlobalBounds();
    }
}
