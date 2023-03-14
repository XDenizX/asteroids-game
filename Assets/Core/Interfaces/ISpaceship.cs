using System.Numerics;

namespace Core.Interfaces
{
    public interface ISpaceship : IEntity
    {
        Vector2 Position { get; set; }
        
        float Angle { get; set; }

        bool TryShoot();
    }
}