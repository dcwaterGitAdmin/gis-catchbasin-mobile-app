using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Command
{
    public class UpdateReferenceDataCommand : ICommand
    {
       

        public UpdateReferenceDataCommand()
        {
            
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MaximoServiceLibrary.AppContext.synchronizationService.synchronizeHelperFromMaximoToLocalDb();
            MessageBox.Show("Reference Data Updated. Please logout and re-login application.");
        }
    }
}
