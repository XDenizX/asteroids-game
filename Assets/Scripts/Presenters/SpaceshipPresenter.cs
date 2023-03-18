using System;
using Base;
using Core.Enums;
using Core.Spaceships;
using UnityEngine;
using Views;
using Vector2 = System.Numerics.Vector2;

namespace Presenters
{
    public class SpaceshipPresenter : BasePresenter<Spaceship, SpaceshipView>
    {
        public SpaceshipPresenter(Spaceship model, SpaceshipView view) : base(model, view)
        { }

        public override void Enable()
        {
            Model.PositionChanged += OnPositionChanged;
            Model.AngleChanged += OnAngleChanged;
            Model.SpeedChanged += OnSpeedChanged;
            Model.Destroyed += OnDestroy;
        }

        public override void Disable()
        {
            Model.PositionChanged -= OnPositionChanged;
            Model.AngleChanged -= OnAngleChanged;
            Model.SpeedChanged -= OnSpeedChanged;
            Model.Destroyed -= OnDestroy;
        }
        
        public void OnDamage()
        {
            Model.Destroy();
        }

        public void OnRotateKeyReleased()
        {
            Model.RotateDirection = RotateDirection.None;
        }
        
        public void OnShootKeyPressed()
        {
            Model.TryShoot();
        }

        public void OnRightKeyPressed()
        {
            Model.RotateDirection = RotateDirection.Right;
        }

        public void OnLeftKeyPressed()
        {
            Model.RotateDirection = RotateDirection.Left;
        }

        public void OnMoveKeyReleased()
        {
            Model.IsMoving = false;
        }

        public void OnMoveKeyPressed()
        {
            Model.IsMoving = true;
        }
        
        public void OnChangeWeaponKeyPressed()
        {
            Model.ChangeWeapon();
        }
        
        private void OnDestroy(object sender, EventArgs e)
        {
            Disable();
        }

        private void OnSpeedChanged(object sender, float speed)
        {
            View.SetFlame(speed / Spaceship.MaxSpeed);
        }

        private void OnAngleChanged(object sender, float angle)
        {
            View.SetRotation(Quaternion.Euler(0, 0, angle));
        }

        private void OnPositionChanged(object sender, Vector2 position)
        {
            View.SetPosition(new UnityEngine.Vector2(position.X, position.Y));
        }
    }
}