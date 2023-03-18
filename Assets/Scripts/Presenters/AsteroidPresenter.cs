using System;
using Base;
using Core.CosmicBodies;
using Core.Interfaces;
using UnityEngine;
using Views;
using Vector2 = System.Numerics.Vector2;

namespace Presenters
{
    public class AsteroidPresenter : BasePresenter<Asteroid, AsteroidView>
    {
        public AsteroidPresenter(Asteroid model, AsteroidView view) : base(model, view)
        { }

        public override void Enable()
        {
            Model.PositionChanged += OnPositionChanged;
            Model.DirectionChanged += OnDirectionChanged;
            Model.Destroyed += OnDestroyed;
        }

        public override void Disable()
        {
            Model.PositionChanged -= OnPositionChanged;
            Model.DirectionChanged -= OnDirectionChanged;
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

        private void OnDirectionChanged(object sender, Vector2 direction)
        {
            var directionVector = new UnityEngine.Vector2(direction.X, direction.Y);
            float angle = UnityEngine.Vector2.Angle(UnityEngine.Vector2.right, directionVector);
            View.SetRotation(Quaternion.Euler(0, 0, angle));
        }

        private void OnPositionChanged(object sender, Vector2 position)
        {
            View.SetPosition(new UnityEngine.Vector2(position.X, position.Y));
        }
    }
}