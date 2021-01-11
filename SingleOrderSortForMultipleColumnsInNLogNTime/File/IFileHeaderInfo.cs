namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	public interface IFileHeaderInfo
	{
		bool HasHeader { get; }
		string HeaderColumnsCsv { get; }
		char CsvSplitByCharacter { get; }
	}
}
