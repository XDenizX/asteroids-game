using Core.Interfaces;

namespace Core.Base
{
    public abstract class BaseProjectile : BaseEntity, IProjectile
    {
        public virtual void Hit(ICosmicBody cosmicBody)
        {
            cosmicBody.OnHit(this);
        }
    }
}