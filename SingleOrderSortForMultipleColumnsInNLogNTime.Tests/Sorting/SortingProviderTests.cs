using Moq;
using NUnit.Framework;
using SingleOrderSortForMultipleColumnsInNLogNTime.Extension;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.Sorting
{
	[TestFixture]
	public class SortingProviderTests
	{
		[TestCase(new string[] { "6d,1,2", "1y1m,1,2", "3m2w3d,11,12" }, new string[] { "6d, 1, 2", "3m2w3d, 11, 12", "1y1m, 1, 2" }, true)]
		[TestCase(new string[] { "6d,1,2", "1y1m,1,2", "3m2w3d,11,12" }, new string[] { "6d, 1, 2", "1y1m, 1, 2", "3m2w3d, 11, 12" }, false)]
		public void Sort_Method_Sorts_The_Data_Accordingly_To_The_Given_Order(string[] givenOrder, string[] expectedSortArray, bool forward)
		{
			// need some preprocessing here
			var timeSpanConverter = new TimeSpanConverter();
			var csvFileDataProcessor = new CsvFileDataProcessor(timeSpanConverter, ',');
			var errors = new Dictionary<int, string>();
			var processedSequence = csvFileDataProcessor.ProcessData(givenOrder, givenOrder.Length, false, errors);

			var config = new Mock<IConfiguration>();
			config.SetupProperty(h => h.HasHeader, false);

			var converter = new TimeSpanConverter();
			var sortingProvider = new SortingProvider(config.Object, converter);
			var resultingSort = sortingProvider.Sort(processedSequence, forward);
			var resultingSortArray = resultingSort.ToStringArray();

			Assert.AreEqual(expectedSortArray, resultingSortArray);
		}
	}
}
