using System;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Handles Csv file processing using the required dependencies ("S"ol"ID")
	/// </summary>
	public class CsvFileDataProcessor : ICsvFileDataProcessor
	{
		private ITimeSpanConverter _converter;
		private char _csvSplitByCharacter;
		public CsvFileDataProcessor(ITimeSpanConverter converter, char csvSplitByCharacter)
		{
			_converter = converter;
			_csvSplitByCharacter = csvSplitByCharacter;
		}
		/// <summary>
		/// Performs some data manipulation to ease and make sorting more efficient
		/// </summary>
		/// <param name="data"></param>
		/// <param name="numValidColumns"></param>
		/// <param name="hasHeader"></param>
		/// <param name="errors"></param>
		/// <returns></returns>
		public IList<Tuple<string, string, string>> ProcessData(string[] data, int numValidColumns, bool hasHeader, Dictionary<int, string> errors)
		{
			var list = new List<Tuple<string, string, string>>();
			var errorMessage = string.Empty;
			string[] dataSplits;
			int days;

			for (int index = hasHeader ? 1 : 0; index < data.Length; index++)
			{
				if (data[index].Length > 0)
				{
					dataSplits = data[index].Split(_csvSplitByCharacter);
					if (dataSplits.Length == numValidColumns)
					{
						days = _converter.ConvertToDays(dataSplits[0], out errorMessage);
						if (string.IsNullOrEmpty(errorMessage))
							list.Add(new Tuple<string, string, string>(days.ToString(), dataSplits[1], dataSplits[2]));
						else
							errors.Add(index, errorMessage);
					}
					else
						errors.Add(index, Constants.ErrorNumberOfColumnsDifferFromConfig);
				}
			}

			return list;
		}
	}
}
