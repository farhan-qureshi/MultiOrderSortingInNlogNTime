using System;
using System.Configuration;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	class Program
	{
		static void Main(string[] args)
		{
			// path to access the input file
			var filePath = ConfigurationManager.AppSettings["FilePath"];
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentException("FilePath config value is empty or invalid");

			// whether the file has or not, a header as the first row
			var hasHeader = false;
			var firstLineIsHeaderConfigValue = ConfigurationManager.AppSettings["HasHeader"];
			if (firstLineIsHeaderConfigValue == null || !bool.TryParse(firstLineIsHeaderConfigValue, out hasHeader))
				throw new ArgumentException("HasHeader is empty or invalid");

			// the comma separated header value
			var headerColumnsCsv = string.Empty;
			if (hasHeader)
			{
				headerColumnsCsv = ConfigurationManager.AppSettings["HeaderColumns"];
				if (string.IsNullOrEmpty(headerColumnsCsv))
					throw new ArgumentException("HeaderColumns is empty or invalid");
			}

			// the character used for separation
			string csvSplitByCharacterConfigValue = ConfigurationManager.AppSettings["CsvSplitByCharacter"];
			if (csvSplitByCharacterConfigValue == null || !char.TryParse(csvSplitByCharacterConfigValue, out char csvSplitByCharacter))
				throw new ArgumentException("CsvSplitByCharacter is empty or invalid");

			// sorting with timespan first then dataset (then value)
			var outputFilePathTimespanDatasetSort = ConfigurationManager.AppSettings["OutputFilePathTimespanDatasetSort"];
			if (string.IsNullOrEmpty(outputFilePathTimespanDatasetSort))
				throw new ArgumentException("OutputFilePathTimespanDatasetSort config value is empty or invalid");

			// sorting with dataset first then timespan (then value)
			var outputFilePathDatasetTimespanSort = ConfigurationManager.AppSettings["OutputFilePathDatasetTimespanSort"];
			if (string.IsNullOrEmpty(outputFilePathDatasetTimespanSort))
				throw new ArgumentException("OutputFilePathDatasetTimespanSort config value is empty or invalid");

			// All the processes run from this point onwards by the orchestrator
			var orchestrator = new Orchestrator(filePath, hasHeader, headerColumnsCsv, csvSplitByCharacter, outputFilePathTimespanDatasetSort, outputFilePathDatasetTimespanSort);
			orchestrator.Process();
		}
	}
}
