using System;
using System.Numerics;
using Base;
using Core.Interfaces;
using Core.Projectiles;
using Views;
using Quaternion = UnityEngine.Quaternion;

namespace Presenters
{
    public class RayPresenter : BasePresenter<Ray, RayView>
    {
        public RayPresenter(Ray model, RayView view) : base(model, view)
        { }

        public override void Enable()
        {
            Model.EmissionPointChanged += OnEmissionPointChanged;
            Model.DirectionChanged += OnDirectionChanged;
            Model.LengthChanged += OnLengthChanged;
            Model.LifetimeChanged += OnLifetimeChanged;
            Model.Destroyed += OnDestroyed;
        }

        public override void Disable()
        {
            Model.EmissionPointChanged -= OnEmissionPointChanged;
            Model.DirectionChanged -= OnDirectionChanged;
            Model.LengthChanged -= OnLengthChanged;
            Model.LifetimeChanged -= OnLifetimeChanged;
            Model.Destroyed -= OnDestroyed;
        }
        
        public IProjectile GetModel()
        {
            return Model;
        }
        
        private void OnDestroyed(object sender, EventArgs e)
        {
            Disable();
        }

        private void OnLifetimeChanged(object sender, float lifetime)
        {
            View.SetWidth(lifetime);
        }

        private void OnLengthChanged(object sender, float length)
        {
            View.SetLength(length);
        }

        private void OnDirectionChanged(object sender, float direction)
        {
            View.SetRotation(Quaternion.Euler(0, 0, direction));
        }

        private void OnEmissionPointChanged(object sender, Vector2 emissionPoint)
        {
            View.SetPosition(new UnityEngine.Vector2(emissionPoint.X, emissionPoint.Y));
        }
    }
}