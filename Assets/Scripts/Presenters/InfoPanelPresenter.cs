using System;
using System.Linq;
using System.Numerics;
using Base;
using Core.Spaceships;
using Core.Weapons;
using Views;

namespace Presenters
{
    public class InfoPanelPresenter : BasePresenter<Spaceship, InfoPanelView>
    {
        private Laser _laser;
        
        public InfoPanelPresenter(Spaceship model, InfoPanelView view) : base(model, view)
        { }
        
        public override void Enable()
        {
            Model.PositionChanged += OnPositionChanged;
            Model.AngleChanged += OnAngleChanged;
            Model.SpeedChanged += OnSpeedChanged;
            Model.Destroyed += OnDestroyed;

            View.DisplayPosition(Model.Position);
            View.DisplayAngle(Model.Angle);
            View.DisplaySpeed(Model.Speed);
            
            _laser = Model.AvailableWeapons
                .OfType<Laser>()
                .FirstOrDefault();

            if (_laser == null) 
                return;
            
            _laser.AvailableAmmoChanged += OnAmmoChanged;
            _laser.RollbackTimeLeftChanged += OnRollbackTimeChanged;
            
            View.DisplayLaserAmmo(_laser.AvailableAmmo);
            View.DisplayLaserRollbackTime(_laser.RollbackTimeLeft);
        }

        public override void Disable()
        {
            Model.PositionChanged -= OnPositionChanged;
            Model.AngleChanged -= OnAngleChanged;
            Model.SpeedChanged -= OnSpeedChanged;
            Model.Destroyed -= OnDestroyed;
            
            if (_laser == null)
                return;
            
            _laser.AvailableAmmoChanged -= OnAmmoChanged;
            _laser.RollbackTimeLeftChanged -= OnRollbackTimeChanged;
        }

        private void OnDestroyed(object sender, EventArgs e)
        {
            Disable();
        }

        private void OnRollbackTimeChanged(object sender, float time)
        {
            View.DisplayLaserRollbackTime(time);
        }

        private void OnAmmoChanged(object sender, int ammo)
        {
            View.DisplayLaserAmmo(ammo);
        }

        private void OnSpeedChanged(object sender, float speed)
        {
            View.DisplaySpeed(speed);
        }

        private void OnAngleChanged(object sender, float angle)
        {
            View.DisplayAngle(angle);
        }

        private void OnPositionChanged(object sender, Vector2 position)
        {
            View.DisplayPosition(position);
        }
    }
}