using Base;
using Core;

namespace Commands
{
    public class ReplayCommand : BaseTypedCommand<Game>
    {
        public override void Execute(Game game)
        {
            game.Restart();
        }
    }
}