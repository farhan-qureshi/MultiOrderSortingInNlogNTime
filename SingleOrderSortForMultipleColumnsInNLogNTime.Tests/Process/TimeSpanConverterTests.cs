using NUnit.Framework;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.Process
{
	[TestFixture]
	public class TimeSpanConverterTests
	{
		[TestCase("2y", 2 * Constants.DaysInAYear)]
		[TestCase("1m", 1 * Constants.DaysInAMonth)]
		[TestCase("3w", 3 * Constants.DaysInAWeek)]
		[TestCase("4d", 4 * Constants.DaysInADay)]
		[TestCase("1y8m", 1 * Constants.DaysInAYear + 8 * Constants.DaysInAMonth)]
		[TestCase("2m5w8d", 2 * Constants.DaysInAMonth + 5 * Constants.DaysInAWeek + 8 * Constants.DaysInADay)]
		[TestCase("1y1m1w1d", 1 * Constants.DaysInAYear + 1 * Constants.DaysInAMonth + 1 * Constants.DaysInAWeek + 1 * Constants.DaysInADay)]
		[TestCase("1y2m3w4d", 1 * Constants.DaysInAYear + 2 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 4 * Constants.DaysInADay)]
		[TestCase("2d1y3w5m", 1 * Constants.DaysInAYear + 5 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 2 * Constants.DaysInADay)]
		[TestCase("1m4d3w3y", 3 * Constants.DaysInAYear + 1 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 4 * Constants.DaysInADay)]
		public void ConvertToDays_Returns_Correct_NumberOfDays(string timeSpan, int expectedDays)
		{
			var timeSpanConverter = new TimeSpanConverter();
			var errorMessage = string.Empty;
			var days = timeSpanConverter.ConvertToDays(timeSpan, out errorMessage);

			Assert.AreEqual(expectedDays, days);
		}

		[TestCase("2y", 2 * Constants.DaysInAYear)]
		[TestCase("1m", 1 * Constants.DaysInAMonth)]
		[TestCase("3w", 3 * Constants.DaysInAWeek)]
		[TestCase("4d", 4 * Constants.DaysInADay)]
		[TestCase("1y8m", 1 * Constants.DaysInAYear + 8 * Constants.DaysInAMonth)]
		[TestCase("2m3w6d", 2 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 6 * Constants.DaysInADay)]
		[TestCase("1y1m1w1d", 1 * Constants.DaysInAYear + 1 * Constants.DaysInAMonth + 1 * Constants.DaysInAWeek + 1 * Constants.DaysInADay)]
		[TestCase("1y2m3w4d", 1 * Constants.DaysInAYear + 2 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 4 * Constants.DaysInADay)]
		[TestCase("1y5m3w2d", 1 * Constants.DaysInAYear + 5 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 2 * Constants.DaysInADay)]
		[TestCase("3y1m3w4d", 3 * Constants.DaysInAYear + 1 * Constants.DaysInAMonth + 3 * Constants.DaysInAWeek + 4 * Constants.DaysInADay)]
		public void ConvertToTimespan_Returns_Correct_NumberOfDays(string expectedTimeSpan, int days)
		{
			var timeSpanConverter = new TimeSpanConverter();
			var errorMessage = string.Empty;
			var timeSpan = timeSpanConverter.ConvertToTimespan(days);

			Assert.AreEqual(expectedTimeSpan, timeSpan);
		}
	}
}
