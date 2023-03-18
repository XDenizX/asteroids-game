using System.Collections.Generic;
using Base;
using Core.Extensions;
using Core.Interfaces;
using Interfaces;
using Presenters;
using UnityEngine;

namespace Views
{
    public class FragmentView : BaseView<FragmentPresenter>, ICosmicBodyView
    {
        [SerializeField] private List<Sprite> fragmentsSprites;
        [SerializeField] private SpriteRenderer body;

        private void Start()
        {
            body.sprite = fragmentsSprites.GetRandom();
        }

        public void OnHit(IProjectile projectile)
        {
            Presenter.OnHit(projectile);
        }
    }
}