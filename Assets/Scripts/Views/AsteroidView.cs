using System.Collections.Generic;
using Base;
using Components;
using Core.Extensions;
using Core.Interfaces;
using Interfaces;
using Presenters;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(BlowEffect))]
    public class AsteroidView : BaseView<AsteroidPresenter>, ICosmicBodyView
    {
        [SerializeField] private List<Sprite> asteroidsSprites;
        [SerializeField] private SpriteRenderer body;

        private BlowEffect _blowEffect;
        
        private void Start()
        {
            _blowEffect = GetComponent<BlowEffect>();
            
            body.sprite = asteroidsSprites.GetRandom();
        }
        
        public void OnHit(IProjectile projectile)
        {
            Presenter.OnHit(projectile);
            _blowEffect.Play();
        }
    }
}