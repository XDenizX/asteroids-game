using Interfaces;

namespace Base
{
    public abstract class BasePresenter<TModel, TView> : IPresenter where TView : class, IView
    {
        protected TModel Model { get; }
        protected TView View { get; }
        
        public abstract void Enable();

        public abstract void Disable();

        protected BasePresenter(TModel model, TView view)
        {
            Model = model;
            View = view;
            View.Presenter = this;
        }
    }
}