using System;
using System.Text;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// A utility to convert the timespan into an integer value to assist sorting ("S"ol"ID")
	/// </summary>
	public class TimeSpanConverter : ITimeSpanConverter
	{
		/// <summary>
		/// To parse a timeSpan into a unique integer value in algorithmic time complexity of O(1)
		/// </summary>
		/// <param name="timeSpan"></param>
		/// <returns></returns>
		public int ConvertToDays(string timeSpan, out string errorMessage)
		{
			errorMessage = string.Empty;
			if (!IsValidTimeSpan(timeSpan, out errorMessage)) return 0;

			int days = 0;
			int previousMatchIndex = 0;

			for (int index = 0; index < timeSpan.Length; index++)
			{
				switch (timeSpan[index])
				{
					case Constants.YearIndicator:
						days += GetDaysForUnit(timeSpan, index, Constants.DaysInAYear, ref previousMatchIndex);
						break;

					case Constants.MonthIndicator:
						days += GetDaysForUnit(timeSpan, index, Constants.DaysInAMonth, ref previousMatchIndex);
						break;

					case Constants.WeekIndicator:
						days += GetDaysForUnit(timeSpan, index, Constants.DaysInAWeek, ref previousMatchIndex);
						break;

					case Constants.DayIndicator:
						days += GetDaysForUnit(timeSpan, index, Constants.DaysInADay, ref previousMatchIndex);
						break;
				}
			}

			return days;
		}

		/// <summary>
		/// Getting Time Span in O(1)
		/// </summary>
		/// <param name="days"></param>
		/// <returns></returns>
		public string ConvertToTimespan(int days)
		{
			var strBuilder = new StringBuilder();
			if(days >= Constants.DaysInAYear)
				strBuilder.Append(GetTimeSpan(Constants.YearIndicator, Constants.DaysInAYear, ref days));

			if (days >= Constants.DaysInAMonth && days < Constants.DaysInAYear)
				strBuilder.Append(GetTimeSpan(Constants.MonthIndicator, Constants.DaysInAMonth, ref days));

			if (days >= Constants.DaysInAWeek && days < Constants.DaysInAMonth)
				strBuilder.Append(GetTimeSpan(Constants.WeekIndicator, Constants.DaysInAWeek, ref days));

			if (days >= Constants.DaysInADay && days < Constants.DaysInAWeek)
				strBuilder.Append(GetTimeSpan(Constants.DayIndicator, Constants.DaysInADay, ref days));

			return strBuilder.ToString();
		}

		private static int GetDaysForUnit(string timeSpan, int index, int unitDays, ref int previousMatchIndex)
		{
			var days = int.Parse(timeSpan.Substring(previousMatchIndex, index - previousMatchIndex)) * unitDays;
			previousMatchIndex = index + 1;
			return days;
		}

		private static bool IsValidTimeSpan(string timeSpan, out string errorMessage)
		{
			var isValid = true;
			errorMessage = string.Empty;

			if (string.IsNullOrEmpty(timeSpan))
			{
				errorMessage = Constants.NullOrEmptyTimeSpanError;
				return false;
			}

			var yearOccurence = 0;
			var monthOccurence = 0;
			var weekOccurence = 0;
			var dayOccurence = 0;

			for (int index = 0; index < timeSpan.Length; index++)
			{
				switch (timeSpan[index])
				{
					case Constants.YearIndicator:
						if (yearOccurence++ == 1)
						{
							errorMessage = Constants.InvalidYearInTimeSpanError;
							return false;
						}
						break;

					case Constants.MonthIndicator:
						if (monthOccurence++ == 1)
						{
							errorMessage = Constants.InvalidMonthInTimeSpanError;
							return false;
						}
						break;

					case Constants.WeekIndicator:
						if (weekOccurence++ == 1)
						{
							errorMessage = Constants.InvalidWeekInTimeSpanError;
							return false;
						}
						break;

					case Constants.DayIndicator:
						if (dayOccurence++ == 1)
						{
							errorMessage = Constants.InvalidDayInTimeSpanError;
							return false;
						}
						break;
				}
			}

			return isValid;
		}

		private static string GetTimeSpan(char unit, int daysPerUnit, ref int days)
		{
			string unitPart = string.Empty;
			int rem = 0;
			int div = 0;
			if (days >= daysPerUnit)
			{
				div = Math.DivRem(days, daysPerUnit, out rem);
				unitPart = $"{div}{unit}";
			}

			days = rem;

			return unitPart;
		}
	}
}
