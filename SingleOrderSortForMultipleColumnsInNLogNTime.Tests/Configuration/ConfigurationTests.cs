using NUnit.Framework;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.Configuration
{
	[TestFixture]
	public class ConfigurationTests
	{
		[Test]
		public void Configuration_Has_Correct_Assignments()
		{
			// create a configuration object with some values and then verify that the values are same
			string filePath = "1.txt";
			bool hasHeader = true;
			string columnHeadersCsv = "one,two,teoco";
			char csvSplitByCharacter = ',';
			string outputFilePathTimespanDatasetSort = "output1.txt";
			string outputFilePathDatasetTimespanSort = "output2.txt";

			// create the config object
			var config = new SingleOrderSortForMultipleColumnsInNLogNTime.Configuration(filePath, hasHeader, columnHeadersCsv, csvSplitByCharacter, outputFilePathTimespanDatasetSort, outputFilePathDatasetTimespanSort);

			// verify that the constructor has assigned the values to its property correctly.
			Assert.AreEqual(filePath, config.FilePath);
			Assert.AreEqual(hasHeader, config.HasHeader);
			Assert.AreEqual(columnHeadersCsv, config.ColumnHeadersCsv);
			Assert.AreEqual(csvSplitByCharacter, config.CsvSplitByCharacter);
			Assert.AreEqual(outputFilePathTimespanDatasetSort, config.OutputFilePathTimespanDatasetSort);
			Assert.AreEqual(outputFilePathDatasetTimespanSort, config.OutputFilePathDatasetTimespanSort);
		}
	}
}
