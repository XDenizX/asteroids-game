using System;
using System.Numerics;
using Core.Base;
using Core.Interfaces;

namespace Core.CosmicBodies
{
    public class Saucer : BaseCosmicBody
    {
        private const float MaxSpeed = 1.5f;
        private const float Acceleration = 0.3f;

        private Vector2 _position;
        private float _speed;

        private readonly ISpaceship _target;

        public event EventHandler<Vector2> PositionChanged;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(this, _position);
            }
        }

        public Saucer(ISpaceship target)
        {
            _target = target;
        }

        public override void Simulate(float deltaTime)
        {
            if (_speed < MaxSpeed)
                _speed += Acceleration;
            
            Vector2 direction = _target.Position - _position;
            direction = Vector2.Normalize(direction);
            
            Position += direction * _speed * deltaTime;
        }
    }
}