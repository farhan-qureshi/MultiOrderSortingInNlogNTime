namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	public interface IConfiguration
	{
		string FilePath { get; set; }
		bool HasHeader { get; set; }
		string ColumnHeadersCsv { get; }
		char CsvSplitByCharacter { get; }
		string OutputFilePathTimespanDatasetSort { get; }
		string OutputFilePathDatasetTimespanSort { get; }
	}
}
