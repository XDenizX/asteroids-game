using System.Numerics;
using Core.Base;
using Core.CosmicBodies;
using Core.Interfaces;
using Core.Utils;

namespace Core.Spawners
{
    public class SaucerSpawner : BaseSpawner<Saucer>
    {
        private readonly ISpaceship _spaceship;
        
        public float SpawnRadius { get; set; } 
        
        public SaucerSpawner(ISpaceship target, float produceTime) : base(produceTime)
        {
            _spaceship = target;
        }

        public override Saucer Produce()
        {
            Vector2 spawnPosition = MathUtils.RandomOnCircle(SpawnRadius);
            
            return new Saucer(_spaceship)
            {
                Position = spawnPosition
            };
        }
    }
}