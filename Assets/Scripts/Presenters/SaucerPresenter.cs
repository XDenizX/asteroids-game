using System;
using System.Numerics;
using Base;
using Core.CosmicBodies;
using Core.Interfaces;
using Views;

namespace Presenters
{
    public class SaucerPresenter : BasePresenter<Saucer, SaucerView>
    {
        public SaucerPresenter(Saucer model, SaucerView view) : base(model, view)
        { }

        public override void Enable()
        {
            Model.PositionChanged += OnPositionChanged;
            Model.Destroyed += OnDestroyed;
        }

        public override void Disable()
        {
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
    }
}