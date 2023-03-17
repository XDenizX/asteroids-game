using System;
using System.Numerics;
using Core.Base;
using Core.CosmicBodies;
using Core.Utils;

namespace Core.Spawners
{
    public class AsteroidSpawner : BaseSpawner<Asteroid>
    {
        private readonly Random _random = new();
        
        public float SpawnRadius { get; set; }
        public float TargetAreaRadius { get; set; }
        
        public AsteroidSpawner(float produceTime) : base(produceTime)
        { }

        public override Asteroid Produce()
        {
            var speed = (float)(1 + _random.NextDouble());
            Vector2 spawnPosition = MathUtils.RandomOnCircle(SpawnRadius);
            Vector2 direction = GetRandomDirection(spawnPosition);

            return new Asteroid
            {
                Position = spawnPosition,
                Direction = direction,
                Speed = speed
            };
        }

        private Vector2 GetRandomDirection(Vector2 spawnPosition)
        {
            Vector2 targetPosition = MathUtils.RandomOnCircle(TargetAreaRadius);
            Vector2 direction = targetPosition - spawnPosition;

            return Vector2.Normalize(direction);
        }
    }
}