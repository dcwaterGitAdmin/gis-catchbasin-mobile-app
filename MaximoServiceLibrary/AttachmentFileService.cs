using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoServiceLibrary
{
	public class AttachmentFileService
	{
		// TODO - read folder path from config
		private string attachmentFolderPath = "C:\\CatchBasin\\attachments";

		public string generateFileName(int docinfoid, string fileName)
		{
			string path = $"{attachmentFolderPath}\\{docinfoid}_{fileName}";
			return path;
		}

		public void deleteAttachment(MaximoDocLinks docLink)
		{
			String path = generateFileName(docLink.docinfoid, docLink.fileName);
			try
			{
				FileInfo file = new FileInfo(path);
				file.Delete();
			}
			catch (Exception ex)
			{
				AppContext.Log.Error(ex);
			}
		}

		public void deleteAllAttachments()
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(attachmentFolderPath);

				foreach (FileInfo file in directoryInfo.GetFiles())
				{
					file.Delete();
				}
			}
			catch (Exception ex)
			{
				AppContext.Log.Error(ex.StackTrace);
			}

		}
	}
}
