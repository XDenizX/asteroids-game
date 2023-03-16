using System;
using Core.Base;
using Core.Interfaces;
using Core.Projectiles;

namespace Core.Weapons
{
    public class Laser : BaseWeapon<Ray>
    {
        private const int MaxAmmo = 3;
        private const float RollbackTime = 2f;
        private const float AmmoRecoveryTime = 15f;
        
        private int _availableAmmo;
        private float _rollbackTime;
        private float _recoveryTime;

        public event EventHandler<int> AvailableAmmoChanged;
        public event EventHandler<float> RollbackTimeLeftChanged; 

        public int AvailableAmmo
        {
            get => _availableAmmo;
            set
            {
                _availableAmmo = value;
                AvailableAmmoChanged?.Invoke(this, _availableAmmo);
            }
        }
        
        public float RollbackTimeLeft
        {
            get => _rollbackTime;
            set
            {
                _rollbackTime = value;
                RollbackTimeLeftChanged?.Invoke(this, _rollbackTime);
            }
        }
        
        public Laser(ISpaceship owner) : base(owner)
        {
            AvailableAmmo = MaxAmmo;
            RollbackTimeLeft = RollbackTime;
        }

        public override bool CanShoot()
        {
            return _availableAmmo > 0 && _rollbackTime <= 0;
        }

        public override void OnShoot()
        {
            RollbackTimeLeft = RollbackTime;
            AvailableAmmo--;
        }

        public override void Simulate(float deltaTime)
        {
            EvaluateRollbackTime(deltaTime);
            EvaluateRecoveryTime(deltaTime);
        }

        protected override Ray CreateProjectile()
        {
            return new Ray(Owner);
        }
        
        private void EvaluateRollbackTime(float deltaTime)
        {
            if (_rollbackTime > 0)
                RollbackTimeLeft -= deltaTime;
        }

        private void EvaluateRecoveryTime(float deltaTime)
        {
            if (AvailableAmmo >= MaxAmmo) 
                return;
            
            if (_recoveryTime > 0)
            {
                _recoveryTime -= deltaTime;
            }
            else
            {
                _recoveryTime = AmmoRecoveryTime;
                AvailableAmmo++;
            }
        }
    }
}