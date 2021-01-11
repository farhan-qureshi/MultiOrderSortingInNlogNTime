using SingleOrderSortForMultipleColumnsInNLogNTime.Extension;
using System;
using System.Collections.Generic;
using System.IO;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Responsible for performing low level file operations. This is the lowest level of abstraction (soli"D")
	/// </summary>
	public class FileDataProvider : IFileDataProvider
	{
		private IFilePathValidator _filePathValidator;
		private IFileHeaderInfo _fileHeaderInfo;
		private IFilePathInfo _filePathInfo;
		public FileDataProvider(IFilePathValidator filePathValidator, IFileHeaderInfo fileHeaderInfo, IFilePathInfo filePathInfo)
		{
			_filePathValidator = filePathValidator;
			_fileHeaderInfo = fileHeaderInfo;
			_filePathInfo = filePathInfo;
		}
		/// <summary>
		/// Reads the content of the file using the configration
		/// </summary>
		/// <returns></returns>
		public string[] Read()
		{
			if(!_filePathValidator.IsValidInputFilePath())
				throw new Exception("File does not exist. Please correct the configuration settings.");

			string[] lines = File.ReadAllLines(_filePathInfo.FilePath);
			if(_fileHeaderInfo.HasHeader && lines.Length > 0)
				if(lines[0].Replace(" ","") != _fileHeaderInfo.HeaderColumnsCsv)
					throw new Exception("File content/data is not valid according to the configuration.");
			
			return lines;
		}

		/// <summary>
		/// Writes the results of the timespan then dataset ordered content
		/// </summary>
		/// <param name="content"></param>
		public void WriteWithTimespanThenDatasetOrder(IList<Tuple<string, string, string>> content)
		{
			try
			{
				if (File.Exists(_filePathInfo.OutputFilePathTimespanDatasetSort))
					File.Delete(_filePathInfo.OutputFilePathTimespanDatasetSort);

				File.AppendAllLines(_filePathInfo.OutputFilePathTimespanDatasetSort, content.ToStringArray());
			}
			catch(Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Writes the results of the dataset and then timespan ordered content
		/// </summary>
		/// <param name="content"></param>
		public void WriteWithDatasetThenTimespanOrder(IList<Tuple<string, string, string>> content)
		{
			try
			{
				if (File.Exists(_filePathInfo.OutputFilePathDatasetTimespanSort))
					File.Delete(_filePathInfo.OutputFilePathDatasetTimespanSort);

				File.WriteAllLines(_filePathInfo.OutputFilePathDatasetTimespanSort, content.ToStringArray());
			}
			catch(Exception e)
			{
				throw e;
			}
		}
	}
}
