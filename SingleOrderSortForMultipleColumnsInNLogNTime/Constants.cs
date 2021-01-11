namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	public static class Constants
	{
		public const int DaysInAYear = 365;
		public const int DaysInAMonth = 30;
		public const int DaysInAWeek = 7;
		public const int DaysInADay = 1;

		public const char YearIndicator = 'y';
		public const char MonthIndicator = 'm';
		public const char WeekIndicator = 'w';
		public const char DayIndicator = 'd';

		public const string NullOrEmptyTimeSpanError = "time span value is null or empty";
		public const string InvalidYearInTimeSpanError = "time span value has multiple ocurrences of year";
		public const string InvalidMonthInTimeSpanError = "time span value has multiple ocurrences of month";
		public const string InvalidWeekInTimeSpanError = "time span value has multiple ocurrences of week";
		public const string InvalidDayInTimeSpanError = "time span value has multiple ocurrences of day";

		public const string ErrorNumberOfColumnsDifferFromConfig = "The number of columns supplied on this line differ from the config value";
	}
}
