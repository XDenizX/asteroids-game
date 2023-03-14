namespace Core.Interfaces
{
    public interface IProjectile : IEntity
    {
        void Hit(ICosmicBody cosmicBody);
    }
}