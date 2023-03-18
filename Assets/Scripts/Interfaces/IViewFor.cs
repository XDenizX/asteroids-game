namespace Interfaces
{
    public interface IViewFor<TPresenter> : IView
    {
        new TPresenter Presenter { get; set; }
    }
}