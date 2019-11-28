using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CatchBasin.ViewModel.Helper;
namespace CatchBasin.ViewModel.Command
{
    class CancelCommand<T> : ICommand where T : IDetailVM
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        T VM;

        public CancelCommand(T vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Cancel();
        }

    }
}
