using System;
using Base;
using Commands;
using Core;
using Views;

namespace Presenters
{
    public class ReplayWindowPresenter : BasePresenter<Game, ReplayWindowView>
    {
        private readonly QuitCommand _quitCommand;
        private readonly ReplayCommand _replayCommand;
        
        public ReplayWindowPresenter(Game model, ReplayWindowView view) : base(model, view)
        {
            _quitCommand = new QuitCommand();
            _replayCommand = new ReplayCommand();
        }

        public override void Enable()
        {
            Model.Player.Destroyed += ShowReplayWindow;
        }
        
        public override void Disable()
        {
            Model.Player.Destroyed -= ShowReplayWindow;
        }

        public void Replay()
        {
            _replayCommand.Execute(Model);
        }

        public void Quit()
        {
            _quitCommand.Execute(null);
        }
        
        private void ShowReplayWindow(object sender, EventArgs e)
        {
            View.Show();
            View.DisplayScore(Model.Score);
        }
    }
}