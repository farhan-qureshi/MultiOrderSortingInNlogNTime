namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Contains useful necessary information about File Header ("S"olid)
	/// </summary>
	public class FileHeaderInfo : IFileHeaderInfo
	{
		private IConfiguration _configuration;
		public FileHeaderInfo(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public bool HasHeader
		{
			get
			{
				return _configuration.HasHeader;
			}
		}
		public string HeaderColumnsCsv
		{
			get
			{
				return _configuration.ColumnHeadersCsv;
			}
		}

		public char CsvSplitByCharacter
		{
			get
			{
				return _configuration.CsvSplitByCharacter;
			}
		}
	}
}
