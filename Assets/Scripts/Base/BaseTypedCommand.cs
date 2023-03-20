using Interfaces;

namespace Base
{
    public abstract class BaseTypedCommand<T> : ICommand where T : class
    {
        public abstract void Execute(T argument);

        void ICommand.Execute(object argument)
        {
            Execute(argument as T);
        }
    }
}