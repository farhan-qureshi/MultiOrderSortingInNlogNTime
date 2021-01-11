using System;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Orchestrator is like a main constroller that has an eye over main operations
	/// </summary>
	internal class Orchestrator : IOrchestrator
	{
		private string _filePath;
		private bool _hasHeader;
		private string _headerColumns;
		private char _csvSplitByCharacter;
		private string _outputFilePathTimespanDatasetSort;
		private string _outputFilePathDatasetTimespanSort;
		public Orchestrator(string filePath, bool hasHeader, string headerColumns, char csvSplitByCharacter, string outputFilePathTimespanDatasetSort, string outputFilePathDatasetTimespanSort)
		{
			_filePath = filePath;
			_hasHeader = hasHeader;
			_headerColumns = headerColumns;
			_csvSplitByCharacter = csvSplitByCharacter;
			_outputFilePathTimespanDatasetSort = outputFilePathTimespanDatasetSort;
			_outputFilePathDatasetTimespanSort = outputFilePathDatasetTimespanSort;
		}
		/// <summary>
		/// Process methods does the needful and creates the objects required using the Factory method
		/// </summary>
		public void Process()
		{
			try
			{
				// Initialising the properties of the Factory
				DataProcessFactory.Initialize(_filePath, _hasHeader, _headerColumns, _csvSplitByCharacter, _outputFilePathTimespanDatasetSort, _outputFilePathDatasetTimespanSort);

				// Instantiating the provider for File related operations
				var fileDataProvider = (IFileDataProvider)DataProcessFactory.Create<IFileDataProvider>();

				// Instantiating the provider for Csv data related operations
				var csvFileDataProcessor = (ICsvFileDataProcessor)DataProcessFactory.Create<ICsvFileDataProcessor>();

				// Instantiating the provider for sorting operations
				var sortingProvider = (ISortingProvider)DataProcessFactory.Create<ISortingProvider>();

				// At this point, we have read all the data in the input file
				var allData = fileDataProvider.Read();

				// The read data is processed, mainly the timespan value, any errors are that come during the process are recorded and then returned
				var errorsByLine = new Dictionary<int, string>();
				var dateWithTimeSpanConvertedToNumber = csvFileDataProcessor.ProcessData(allData, _headerColumns.Split(_csvSplitByCharacter).Length, _hasHeader, errorsByLine);

				// Sort by TimeSpan, Dataset, Value
				var sortedNormally = sortingProvider.Sort(dateWithTimeSpanConvertedToNumber, true);
				// Write to the desired output file
				fileDataProvider.WriteWithTimespanThenDatasetOrder(sortedNormally);

				// Sort by Dataset, TimeSpan , Value
				var sortedInReverse = sortingProvider.Sort(dateWithTimeSpanConvertedToNumber, false);
				// Write to the desired output file
				fileDataProvider.WriteWithDatasetThenTimespanOrder(sortedInReverse);

				if (errorsByLine.Count > 0)
				{
					foreach (var error in errorsByLine)
						Console.WriteLine($"Line {error.Key} : {error.Value}");
				}
			}
			catch(Exception ex)
			{
				Console.Write(ex);
			}
		}
	}
}
