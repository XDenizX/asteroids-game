using Interfaces;
using UnityEngine;

namespace Commands
{
    public class QuitCommand : ICommand
    {
        public void Execute(object argument)
        {
            Application.Quit();
        }
    }
}