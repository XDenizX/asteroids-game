using Core.Interfaces;

namespace Core.Base
{
    public abstract class BaseCosmicBody : BaseEntity, ICosmicBody
    {
        public void Damage(ISpaceship spaceship)
        {
            spaceship.Destroy();
        }

        public virtual void OnHit(IProjectile projectile)
        {
            EventBus.OnCosmicBodyHit(this);
            Destroy();
        }
    }
}