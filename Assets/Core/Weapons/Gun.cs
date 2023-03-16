using Core.Base;
using Core.Interfaces;
using Core.Projectiles;

namespace Core.Weapons
{
    public class Gun : BaseWeapon<Bullet>
    {
        private const float DefaultBulletRadius = 2f;
        private const float DefaultBulletSpeed = 10f;
        
        public Gun(ISpaceship owner) : base(owner)
        { }
        
        protected override Bullet CreateProjectile()
        {
            return new Bullet
            {
                Radius = DefaultBulletRadius,
                Speed = DefaultBulletSpeed,
                Direction = Owner.Angle,
                Position = Owner.Position
            };
        }

        public override bool CanShoot()
        {
            return true;
        }

        public override void Simulate(float deltaTime)
        {
            // Empty implementation.
        }
    }
}