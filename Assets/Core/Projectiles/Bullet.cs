using System;
using System.Numerics;
using Core.Base;
using Core.Utils;

namespace Core.Projectiles
{
    public class Bullet : BaseProjectile
    {
        private float _radius;
        private Vector2 _position;
        private float _direction;

        public event EventHandler<Vector2> PositionChanged;
        public event EventHandler<float> RadiusChanged;
        public event EventHandler<float> DirectionChanged;

        public float Speed { get; set; }

        public float Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                DirectionChanged?.Invoke(this, _direction);
            }
        }
        
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(this, _position);
            }
        }

        public float Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                RadiusChanged?.Invoke(this, _radius);
            }
        }

        public override void Simulate(float deltaTime)
        {
            base.Simulate(deltaTime);
            
            Position += MathUtils.AngleToVector(Direction) * Speed * deltaTime;
        }
    }
}