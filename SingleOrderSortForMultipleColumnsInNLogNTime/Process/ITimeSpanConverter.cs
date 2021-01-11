namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	public interface ITimeSpanConverter
	{
		int ConvertToDays(string timeSpan, out string errorMessage);
		string ConvertToTimespan(int days);
	}
}
