using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Core.Base;
using Core.Enums;
using Core.Interfaces;
using Core.Utils;
using Core.Weapons;

namespace Core.Spaceships
{
    public class Spaceship : BaseEntity, ISpaceship
    {
        public const float MaxSpeed = 3f;
        private const float Acceleration = 3.5f;
        private const float Deceleration = 1.5f;
        private const float RotationDelta = 90f;

        private float _angle;
        private float _speed;
        private Vector2 _position;

        public event EventHandler<Vector2> PositionChanged;
        public event EventHandler<float> AngleChanged;
        public event EventHandler<float> SpeedChanged;
        
        public List<IWeapon> AvailableWeapons { get; }

        public IWeapon CurrentWeapon { get; set; }

        public bool IsMoving { get; set; }
        
        public RotateDirection RotateDirection { get; set; }

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(this, _position);
            }
        }
        
        public float Angle
        {
            get => _angle;
            set
            {
                _angle = value % 360;
                AngleChanged?.Invoke(this, _angle);
            }
        }
        
        public float Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                SpeedChanged?.Invoke(this, _speed);
            }
        }

        public Spaceship()
        {
            AvailableWeapons = new List<IWeapon>
            {
                new Gun(this),
                new Laser(this)
            };
            
            CurrentWeapon = AvailableWeapons.First();
            AvailableWeapons.ForEach(EventBus.OnCreated);
        }

        public override void Simulate(float deltaTime)
        {
            EvaluateSpeed(deltaTime);
            EvaluateAngle(deltaTime);
            EvaluatePosition(deltaTime);
        }
        
        public bool TryShoot()
        { 
            bool wasShot = CurrentWeapon.TryShoot(out IProjectile projectile);
            if (!wasShot) 
                return false;
            
            EventBus.OnCreated(projectile);

            return true;
        }

        public void ChangeWeapon()
        {
            int currentWeaponIndex = AvailableWeapons.IndexOf(CurrentWeapon);
            CurrentWeapon = currentWeaponIndex == AvailableWeapons.Count - 1 
                ? AvailableWeapons.First() 
                : AvailableWeapons[currentWeaponIndex + 1];
        }

        private void EvaluateSpeed(float deltaTime)
        {
            if (IsMoving)
            {
                if (_speed < MaxSpeed)
                {
                    Speed += Acceleration * deltaTime;
                }
            }
            else
            {
                if (_speed > 0)
                {
                    Speed -= Deceleration * deltaTime;
                }
                else
                {
                    Speed = 0;
                }
            }
        }

        private void EvaluatePosition(float deltaTime)
        {
            Position += MathUtils.AngleToVector(_angle) * _speed * deltaTime;
        }

        private void EvaluateAngle(float deltaTime)
        {
            switch (RotateDirection)
            {
                case RotateDirection.Left:
                    Angle += RotationDelta * deltaTime;
                    break;
                case RotateDirection.Right:
                    Angle -= RotationDelta * deltaTime;
                    break;
            }
        }
    }
}