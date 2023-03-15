using System;
using System.Numerics;
using Core.Base;
using Core.Interfaces;

namespace Core.Projectiles
{
    public class Ray : BaseProjectile
    {
        private const float RayWidth = 1f;
        private const float MaxLength = 150f;
        private const float PropagationSpeed = 30f;
        
        private readonly ISpaceship _spaceship;

        private Vector2 _emissionPoint;
        private float _length;
        private float _direction;
        private float _width;

        public event EventHandler<Vector2> EmissionPointChanged;
        public event EventHandler<float> LengthChanged;
        public event EventHandler<float> DirectionChanged;
        public event EventHandler<float> LifetimeChanged;

        public Vector2 EmissionPoint
        {
            get => _emissionPoint;
            set
            {
                _emissionPoint = value;
                EmissionPointChanged?.Invoke(this, _emissionPoint);
            }
        }
        
        public float Length
        {
            get => _length;
            set
            {
                _length = value;
                LengthChanged?.Invoke(this, _length);
            }
        }

        public float Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                DirectionChanged?.Invoke(this, _direction);
            }
        }
        
        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                LifetimeChanged?.Invoke(this, _width);
            }
        }

        public Ray(ISpaceship spaceship)
        {
            _spaceship = spaceship;
            Width = RayWidth;
        }
        
        public override void Simulate(float deltaTime)
        {
            base.Simulate(deltaTime);
            
            EmissionPoint = _spaceship.Position;
            Direction = _spaceship.Angle;

            if (_length < MaxLength)
                Length += PropagationSpeed * deltaTime;

            if (Width < 0)
            {
                Destroy();
            }
            else
            {
                Width -= deltaTime;
            }
        }
    }
}