using System;
using System.Windows.Input;

namespace MVVMTestApp.Infrastructure.Commands.Base
{
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        abstract public bool CanExecute(object parameter);

        abstract public void Execute(object parameter);
    }
}
