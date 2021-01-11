namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Contains useful necessary information about File Paths ("S"olid)
	/// </summary>
	public class FilePathInfo : IFilePathInfo
	{
		private IConfiguration _configuration;
		public FilePathInfo(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string FilePath
		{
			get
			{
				return _configuration.FilePath;
			}
		}

		public string OutputFilePathTimespanDatasetSort
		{
			get
			{
				return _configuration.OutputFilePathTimespanDatasetSort;
			}
		}

		public string OutputFilePathDatasetTimespanSort
		{
			get
			{
				return _configuration.OutputFilePathDatasetTimespanSort;
			}
		}
	}
}
