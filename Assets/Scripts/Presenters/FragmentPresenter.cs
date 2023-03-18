using System;
using System.Numerics;
using Base;
using Core.CosmicBodies;
using Core.Interfaces;
using Views;
using Quaternion = UnityEngine.Quaternion;

namespace Presenters
{
    public class FragmentPresenter : BasePresenter<Fragment, FragmentView>
    {
        public FragmentPresenter(Fragment model, FragmentView view) : base(model, view)
        { }
        
        public override void Enable()
        {
            Model.DirectionChanged += OnDirectionChanged;
            Model.PositionChanged += OnPositionChanged;
            Model.Destroyed += OnDestroyed;
        }

        public override void Disable()
        {
            Model.DirectionChanged -= OnDirectionChanged;
            Model.PositionChanged -= OnPositionChanged;
            Model.Destroyed -= OnDestroyed;
        }
        
        public void OnHit(IProjectile projectile)
        {
            Model.OnHit(projectile);
        }
        
        private void OnDestroyed(object sender, EventArgs e)
        {
            Disable();
        }

        private void OnPositionChanged(object sender, Vector2 position)
        {
            View.SetPosition(new UnityEngine.Vector2(position.X, position.Y));
        }

        private void OnDirectionChanged(object sender, Vector2 direction)
        {
            var directionVector = new UnityEngine.Vector2(direction.X, direction.Y);
            float angle = UnityEngine.Vector2.Angle(UnityEngine.Vector2.right, directionVector);
            View.SetRotation(Quaternion.Euler(0, 0, angle));
        }
    }
}