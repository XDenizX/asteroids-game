using System;
using System.Numerics;

namespace Core.Utils
{
    public static class MathUtils
    {
        private const float DegreesToRadians = MathF.PI / 180;
        private const float TwoPi = 2 * MathF.PI;
        
        private static readonly Random Random = new();
        
        public static float ConvertToRadians(float angle)
        {
            return angle * DegreesToRadians;
        }

        public static float ConvertToDegrees(float radians)
        {
            return radians / DegreesToRadians;
        }
        
        public static Vector2 AngleToVector(float angle)
        {
            float radians = ConvertToRadians(angle);
            float x = MathF.Cos(radians);
            float y = MathF.Sin(radians);
            
            return new Vector2(x, y);
        }

        public static Vector2 RandomOnCircle(float radius = 1f)
        {
            float randomPoint = (float)Random.NextDouble() * TwoPi;
            float x = MathF.Cos(randomPoint) * radius;
            float y = MathF.Sin(randomPoint) * radius;

            return new Vector2(x, y);
        }
    }
}