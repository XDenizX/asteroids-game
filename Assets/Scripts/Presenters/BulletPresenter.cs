using System;
using Base;
using Core.Projectiles;
using UnityEngine;
using Views;
using Vector2 = System.Numerics.Vector2;

namespace Presenters
{
    public class BulletPresenter : BasePresenter<Bullet, BulletView>
    {
        public BulletPresenter(Bullet model, BulletView view) : base(model, view)
        { }
        
        public override void Enable()
        {
            Model.PositionChanged += OnPositionChanged;
            Model.RadiusChanged += OnRadiusChanged;
            Model.DirectionChanged += OnDirectionChanged;
            Model.Destroyed += OnDestroyed;
            
            View.SetRotation(Quaternion.Euler(0, 0, Model.Direction));
        }

        public override void Disable()
        {
            Model.PositionChanged -= OnPositionChanged;
            Model.RadiusChanged -= OnRadiusChanged;
            Model.DirectionChanged -= OnDirectionChanged;
            Model.Destroyed -= OnDestroyed;
        }
        
        public Bullet GetModel()
        {
            return Model;
        }

        public void Destroy()
        {
            Model.Destroy();
        }

        private void OnDestroyed(object sender, EventArgs e)
        {
            Disable();
        }
        
        private void OnDirectionChanged(object sender, float direction)
        {
            View.SetRotation(Quaternion.Euler(0, 0, direction));
        }

        private void OnRadiusChanged(object sender, float radius)
        {
            View.SetRadius(radius);
        }

        private void OnPositionChanged(object sender, Vector2 position)
        {
            View.SetPosition(new UnityEngine.Vector2(position.X, position.Y));
        }
    }
}