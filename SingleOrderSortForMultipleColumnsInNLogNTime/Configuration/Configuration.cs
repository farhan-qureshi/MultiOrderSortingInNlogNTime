namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Provides a facade to access all configuration related things 
	/// </summary>
	public class Configuration : IConfiguration
	{
		/// <summary>
		/// The path to the input file
		/// </summary>
		public string FilePath { get; set; }
		/// <summary>
		/// Whether or not the input data in the file has a header
		/// </summary>
		public bool HasHeader { get; set; }
		/// <summary>
		/// The headers
		/// </summary>
		public string ColumnHeadersCsv { get; }
		/// <summary>
		/// The character to separate the data columns
		/// </summary>
		public char CsvSplitByCharacter { get; set; }
		/// <summary>
		/// The path where timespan then dataset ordered file is written
		/// </summary>
		public string OutputFilePathTimespanDatasetSort { get; }
		/// <summary>
		/// The path where dataset and then timespan ordered file is written
		/// </summary>
		public string OutputFilePathDatasetTimespanSort { get; }
		public Configuration(string filePath, bool hasHeader, string columnHeadersCsv, char csvSplitByCharacter, string outputFilePathTimespanDatasetSort, string outputFilePathDatasetTimespanSort)
		{
			FilePath = filePath;
			HasHeader = hasHeader;
			ColumnHeadersCsv = columnHeadersCsv;
			CsvSplitByCharacter = csvSplitByCharacter;
			OutputFilePathTimespanDatasetSort = outputFilePathTimespanDatasetSort;
			OutputFilePathDatasetTimespanSort = outputFilePathDatasetTimespanSort;
		}
	}
}
