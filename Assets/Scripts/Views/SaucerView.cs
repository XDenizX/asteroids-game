using Base;
using Components;
using Core.Interfaces;
using Interfaces;
using Presenters;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(BlowEffect))]
    public class SaucerView : BaseView<SaucerPresenter>, ICosmicBodyView
    {
        private BlowEffect _blowEffect;
        
        private void Start()
        {
            _blowEffect = GetComponent<BlowEffect>();
        }

        public void OnHit(IProjectile projectile)
        {
            Presenter.OnHit(projectile);
            _blowEffect.Play();
        }
    }
}