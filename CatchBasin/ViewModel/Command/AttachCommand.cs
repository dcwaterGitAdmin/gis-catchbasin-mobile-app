//using Microsoft.Win32;
using MaximoServiceLibrary.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
                    MaximoDocLinks maximoDocLinks = new MaximoDocLinks();
                    maximoDocLinks.ownertable = "WORKORDER";
                    maximoDocLinks.printthrulink = true;
                    maximoDocLinks.description = "CB REPAIR PHOTO";
                    maximoDocLinks.urltype = "FILE";
                    maximoDocLinks.doctype = "PHOTOS-A";

                    maximoDocLinks.documentdata = DocumentUpload(filename);

                    maximoDocLinks.document = System.IO.Path.GetFileName(filename);
                    if (maximoDocLinks.document.Length > 20)
                    {
                        maximoDocLinks.document = maximoDocLinks.document.Substring(0, 20);
                    }
                    maximoDocLinks.urlname = filename; ;
                    WorkOrderDetailVM.Attachments.Add(maximoDocLinks);
                }
            }
        }

        private string DocumentUpload(string path)
        {
            string base64Data;
            try
            {
                byte[] data = File.ReadAllBytes(path);
                base64Data = Convert.ToBase64String(data);
            }
            catch (Exception)
            {

                throw;
            }
            return base64Data;
        }
    }
}
