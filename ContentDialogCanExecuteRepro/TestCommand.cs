using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ContentDialogCanExecuteRepro;

public class UnexecutableCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    public bool CanExecute(object parameter) => false;
    public void Execute(object parameter)
    {
        if (!CanExecute(null)) throw new UnreachableException();
    }
}
