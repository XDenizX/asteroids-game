using Base;
using Components;
using Interfaces;
using Presenters;
using UnityEngine;

namespace Views
{
    public class BulletView : BaseView<BulletPresenter>
    {
        [SerializeField] private AudioClip bulletShotSound;

        private void Start()
        {
            SoundManager.PlayClip(bulletShotSound);
        }

        public void SetRadius(float radius)
        {
            gameObject.transform.localScale = new Vector3(radius, radius, 1);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isCosmicBody = collision.TryGetComponent(out ICosmicBodyView cosmicBodyView);
            if (!isCosmicBody)
                return;

            cosmicBodyView.OnHit(Presenter.GetModel());
            Presenter.Destroy();
        }
    }
}