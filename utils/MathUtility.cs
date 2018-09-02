using SFML.Graphics;
using SFML.System;
using System;

namespace Utils
{
    public static class MathUtility
    {
        public static float VectorToAngle(Vector2f vector)
        {
            return (float)(Math.Atan2(vector.Y, vector.X) * 180F / Math.PI);
        }

        public static Vector2f AngleToVector(float angle)
        {
            return new Vector2f
            {
                X = (float)Math.Cos(angle * Math.PI / 180f),
                Y = (float)Math.Sin(angle * Math.PI / 180f)
            };
        }
    
        public static void CenterSprite(Sprite sprite)
        {          
            var bounds = sprite.GetGlobalBounds();
            sprite.Origin = new Vector2f((float)Math.Floor((bounds.Left + bounds.Width * 0.5f)), (float)Math.Floor(bounds.Top + bounds.Height * 0.5f));
        }
    }
}
