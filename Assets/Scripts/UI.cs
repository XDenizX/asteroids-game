using System.Collections.Generic;
using Core;
using Interfaces;
using Presenters;
using UnityEngine;
using Views;

public class UI : MonoBehaviour
{
    [SerializeField] private InfoPanelView infoPanelView;
    [SerializeField] private ReplayWindowView replayWindowView;

    private List<IPresenter> _presenters = new();
    
    public void SetGame(Game game)
    {
        _presenters.ForEach(presenter => presenter.Disable());
        
        _presenters = new List<IPresenter>
        {
            new InfoPanelPresenter(game.Player, infoPanelView),
            new ReplayWindowPresenter(game, replayWindowView)
        };

        _presenters.ForEach(presenter => presenter.Enable());
    }
}