using System;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Responsible for creating the desired objects. This is a placeholder for an IoC
	/// </summary>
	internal static class DataProcessFactory
	{
		private static string _filePath;
		private static bool _hasHeader;
		private static string _columnHeadersCsv;
		private static char _csvSplitByCharacter;
		private static string _outputFilePathTimespanDatasetSort;
		private static string _outputFilePathDatasetTimespanSort;

		public static void Initialize(string filePath, bool hasHeader, string columnHeadersCsv, char csvSplitByCharacter, string outputFilePathTimespanDatasetSort, string outputFilePathDatasetTimespanSort)
		{
			_filePath = filePath;
			_hasHeader = hasHeader;
			_columnHeadersCsv = columnHeadersCsv;
			_csvSplitByCharacter = csvSplitByCharacter;
			_outputFilePathTimespanDatasetSort = outputFilePathTimespanDatasetSort;
			_outputFilePathDatasetTimespanSort = outputFilePathDatasetTimespanSort;
		}
		public static object Create<T>()
		{
			var config = new Configuration(_filePath, _hasHeader, _columnHeadersCsv, _csvSplitByCharacter, _outputFilePathTimespanDatasetSort, _outputFilePathDatasetTimespanSort);
			var timeSpanConverter = new TimeSpanConverter();

			if (typeof(T) == typeof(IFileDataProvider))
			{
				var filePathValidator = new FilePathValidator(config);
				var fileHeaderInfo = new FileHeaderInfo(config);
				var filePathInfo = new FilePathInfo(config);
				return new FileDataProvider(filePathValidator, fileHeaderInfo, filePathInfo);
			}

			if (typeof(T) == typeof(ICsvFileDataProcessor))
			{
				return new CsvFileDataProcessor(timeSpanConverter, _csvSplitByCharacter);
			}

			if (typeof(T) == typeof(ISortingProvider))
			{
				return new SortingProvider(config, timeSpanConverter);
			}

			throw new NotImplementedException();
		}
	}
}
