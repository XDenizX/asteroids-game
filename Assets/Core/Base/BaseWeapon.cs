using Core.Interfaces;

namespace Core.Base
{
    public abstract class BaseWeapon<TProjectile> : IWeapon where TProjectile : IProjectile
    {
        protected abstract TProjectile CreateProjectile();

        public ISpaceship Owner { get; set; }

        public abstract bool CanShoot();
        
        public abstract void Simulate(float deltaTime);

        protected BaseWeapon(ISpaceship owner)
        {
            Owner = owner;
        }

        public virtual void OnShoot()
        {
            // Empty implementation.
        }

        public bool TryShoot(out IProjectile projectile)
        {
            bool canShoot = CanShoot();
            if (canShoot)
            {
                projectile = CreateProjectile();
                OnShoot();
            }
            else
            {
                projectile = null;
            }

            return canShoot;
        }

        public void Destroy()
        {
            EventBus.OnDestroy(this);
        }
    }
}