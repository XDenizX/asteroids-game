using System;
using System.Numerics;
using Core.Base;

namespace Core.CosmicBodies
{
    public class Fragment : BaseCosmicBody
    {
        private Vector2 _position;
        private Vector2 _direction;

        public event EventHandler<Vector2> PositionChanged;
        public event EventHandler<Vector2> DirectionChanged;

        public float Speed { get; set; }
        
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(this, _position);
            }
        }
        
        public Vector2 Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                DirectionChanged?.Invoke(this, _direction);
            }
        }
        
        public override void Simulate(float deltaTime)
        {
            base.Simulate(deltaTime);
            
            Position += _direction * Speed * deltaTime;
        }
    }
}