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
    }
}
