//using Microsoft.Win32;
using MaximoServiceLibrary.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Command
{
	class AttachCommand : ICommand
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
		WorkOrderDetailVM WorkOrderDetailVM { get; set; }
		public AttachCommand(WorkOrderDetailVM workOrderDetailVM)
		{
			WorkOrderDetailVM = workOrderDetailVM;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				foreach (string filename in openFileDialog.FileNames)
				{
					MaximoDocument maximoDocument = new MaximoDocument();
					maximoDocument.description = filename;
					maximoDocument.fileName = System.IO.Path.GetFileName(filename);
					maximoDocument.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					WorkOrderDetailVM.Attachments.Add(maximoDocument);
				}
			}
		}
	}
}
