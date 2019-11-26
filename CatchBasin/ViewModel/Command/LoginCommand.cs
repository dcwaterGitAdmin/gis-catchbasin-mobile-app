using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Commands
{
    class LoginCommand : ICommand
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

        LoginVM LoginVM;

        public LoginCommand(LoginVM loginVM)
        {
            LoginVM = loginVM;
        }

        public bool CanExecute(object parameter)
        {
            return LoginVM.UserName != null && LoginVM.UserName != "" && LoginVM.Password != null  && LoginVM.Password != "";
        }

        public void Execute(object parameter)
        {
            LoginVM.DoLogin((System.Windows.Window) parameter);
        }
    }
}
