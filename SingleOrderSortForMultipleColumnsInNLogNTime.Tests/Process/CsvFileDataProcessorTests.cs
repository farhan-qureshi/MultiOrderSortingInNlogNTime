using NUnit.Framework;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.Process
{
	[TestFixture]
	public class CsvFileDataProcessorTests
	{
		[TestCase(new string[] {"1m2w,10,11", "1y2m,12,13", "3w3d,14,15" }, false, ',')]
		[TestCase(new string[] { "4y2d,2,3", "2y2m,12,13", "3w5d,14,15" }, false, ',')]
		[TestCase(new string[] { "1m2w,10,11", "1y2m,12,13", "3w3d,14,15" }, true, ',')]
		[TestCase(new string[] { "4y2d,2,3", "2y2m,12,13", "3w5d,14,15" }, true, ',')]
		public void ProcessData_Returns_Processed_List_Of_Tuples_With_Timespan_Substitions(string[] data, bool hasHeader, char separator)
		{
			var timeSpanConverter = new TimeSpanConverter();
			var csvFileDataProcessor = new CsvFileDataProcessor(timeSpanConverter, separator);

			var errors = new Dictionary<int, string>();
			var results = csvFileDataProcessor.ProcessData(data, data.Length, hasHeader, errors);

			// Assert that when header is provided, the count of data is one less than the data length, hence the first row is ignored
			if (hasHeader)
			{
				// First row is treated as heading
				Assert.AreEqual(data.Length - 1, results.Count);
				Assert.That(results[0].Item2 != data[0].Split(separator)[1]);
				Assert.That(results[0].Item3 != data[0].Split(separator)[2]);

				Assert.That(results[0].Item2 == data[1].Split(separator)[1]);
				Assert.That(results[0].Item3 == data[1].Split(separator)[2]);

				Assert.That(results[1].Item2 == data[2].Split(separator)[1]);
				Assert.That(results[1].Item3 == data[2].Split(separator)[2]);
			}
			else
			{
				// First row is treated as data
				Assert.AreEqual(data.Length, results.Count);

				Assert.That(results[0].Item2 == data[0].Split(separator)[1]);
				Assert.That(results[0].Item3 == data[0].Split(separator)[2]);

				Assert.That(results[1].Item2 == data[1].Split(separator)[1]);
				Assert.That(results[1].Item3 == data[1].Split(separator)[2]);

				Assert.That(results[2].Item2 == data[2].Split(separator)[1]);
				Assert.That(results[2].Item3 == data[2].Split(separator)[2]);
			}
		}
	}
}
