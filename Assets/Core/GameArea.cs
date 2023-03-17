using System.Numerics;
using Core.Interfaces;

namespace Core
{
    public class GameArea : IEntity
    {
        private readonly ISpaceship _spaceship;

        private float _width;
        private float _height;
        private float _halfWidth;
        private float _halfHeight;

        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                _halfWidth = _width / 2;
            }
        }

        public float Height
        {
            get => _height;
            set
            {
                _height = value;
                _halfHeight = _height / 2;
            }
        }

        public GameArea(ISpaceship spaceship, float width, float height)
        {
            _spaceship = spaceship;
            Width = width;
            Height = height;
        }
        
        public void Simulate(float deltaTime)
        {
            Vector2 position = _spaceship.Position;
            
            if (position.X > _halfWidth)
                _spaceship.Position = new Vector2(-_halfWidth, position.Y);
            else if (position.X < -_halfWidth)
                _spaceship.Position = new Vector2(_halfWidth, position.Y);
            
            if (position.Y > _halfHeight)
                _spaceship.Position = new Vector2(position.X, -_halfHeight);
            else if (position.Y < -_halfHeight)
                _spaceship.Position = new Vector2(position.X, _halfHeight);
        }

        public void Destroy()
        {
            EventBus.OnDestroy(this);
        }
    }
}