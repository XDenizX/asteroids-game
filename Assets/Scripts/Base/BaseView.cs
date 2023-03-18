using Interfaces;
using UnityEngine;

namespace Base
{
    public abstract class BaseView<TPresenter> : MonoBehaviour, IViewFor<TPresenter> where TPresenter : class
    {
        public TPresenter Presenter { get; set; }
        
        object IView.Presenter
        {
            get => Presenter;
            set => Presenter = (TPresenter)value;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
        
        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}