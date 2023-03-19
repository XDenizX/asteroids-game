using Base;
using Components;
using Interfaces;
using Presenters;
using UnityEngine;

namespace Views
{
    public class RayView : BaseView<RayPresenter>
    {
        [SerializeField] private SpriteRenderer body;
        [SerializeField] private AudioClip rayShotSound;

        private void Start()
        {
            SoundManager.PlayClip(rayShotSound);
        }

        public void SetWidth(float width)
        {
            var bodyTransform = body.transform;
            bodyTransform.localScale = new Vector3(width, bodyTransform.localScale.y);
        }

        public void SetLength(float length)
        {
            body.size = new Vector2(body.size.x, length);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isCosmicBody = collision.TryGetComponent(out ICosmicBodyView cosmicBodyView);
            if (!isCosmicBody)
                return;

            cosmicBodyView.OnHit(Presenter.GetModel());
        }
    }
}