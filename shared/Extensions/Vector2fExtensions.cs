using SFML.System;

namespace Shared.Extensions
{
    public static class Vector2fExtensions
    {
        public static Vector2f Times(this Vector2f vec2f, float f)
        {
            vec2f.X *= f;
            vec2f.Y *= f;

            return vec2f;
        }
    }
}
