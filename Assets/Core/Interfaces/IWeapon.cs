namespace Core.Interfaces
{
    public interface IWeapon : IEntity
    {
        ISpaceship Owner { get; set; }
        
        bool CanShoot();
        
        bool TryShoot(out IProjectile projectile);
        
        void OnShoot();
    }
}