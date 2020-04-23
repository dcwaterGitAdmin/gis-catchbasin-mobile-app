using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CatchBasin.View;
using MaximoServiceLibrary.model;

namespace CatchBasin.ViewModel.Command
{
    class DeleteAttachmentCommand : ICommand
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

        WorkOrderDetailVM WorkOrderDetailVM;

        public DeleteAttachmentCommand(WorkOrderDetailVM workOrderDetailVM)
        {
            WorkOrderDetailVM = workOrderDetailVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var doc = (MaximoDocLinks)parameter;
            if (doc != null)
            {
                if (doc.docinfoid > 0)
                {
                    MessageBox.Show("You cannot delete this attachment, because it is synced. if you want to delete, please use Maximo");
                }
                else
                {
                    WorkOrderDetailVM.Attachments.Remove((MaximoDocLinks)parameter);
                }
            }
			
		
		}

    }
}
