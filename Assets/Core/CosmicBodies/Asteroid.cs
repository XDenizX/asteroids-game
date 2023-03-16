using Core.Interfaces;
using Core.Projectiles;
using Core.Utils;

namespace Core.CosmicBodies
{
    public class Asteroid : Fragment
    {
        private const int FragmentsCount = 3;

        public override void OnHit(IProjectile projectile)
        {
            base.OnHit(projectile);
            
            if (projectile is not Bullet)
                return;

            CreateFragments();
        }

        private void CreateFragments()
        {
            for (var i = 0; i < FragmentsCount; i++)
            {
                var fragment = new Fragment
                {
                    Direction = MathUtils.RandomOnCircle(),
                    Position = Position,
                    Speed = Speed * 1.5f
                };
                EventBus.OnCreated(fragment);
            }
        }
    }
}