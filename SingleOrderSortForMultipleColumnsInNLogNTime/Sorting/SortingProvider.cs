using System;
using System.Linq;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Performs sorting of data in both directions (timespan first, dataset first), ("S"ol"ID")
	/// </summary>
	public class SortingProvider : ISortingProvider
	{
		private IConfiguration _configuration;
		private ITimeSpanConverter _converter;
		public SortingProvider(IConfiguration configuration, ITimeSpanConverter converter)
		{
			_configuration = configuration;
			_converter = converter;
		}
		/// <summary>
		/// Takes a list of tuples, introduces a calculated index which is a value based on a unique combiation of three columns
		/// </summary>
		/// <param name="data"></param>
		/// <param name="forward"></param>
		/// <returns></returns>
		public IList<Tuple<string, string, string>> Sort(IList<Tuple<string, string, string>> data, bool forward)
		{
			var indexedList = AddIndexersToDataForSorting(data, forward);
			var sortedList = from item in indexedList
							 orderby item.Item1
							select new { item.Item2, item.Item3, item.Item4 };

			var timespanInvertedList = new List<Tuple<string, string, string>>();
			foreach(var sortedListItem in sortedList)
			{
				timespanInvertedList.Add(new Tuple<string, string, string>(_converter.ConvertToTimespan(int.Parse(sortedListItem.Item2))
					, sortedListItem.Item3, sortedListItem.Item4));
			}
			return (IList<Tuple<string, string, string>>)timespanInvertedList;
		}

		private IList<Tuple<double, string, string, string>> AddIndexersToDataForSorting(IList<Tuple<string, string, string>> data, bool forward)
		{
			var indexed = new List<Tuple<double, string, string, string>>();
			double sortIndex; 
			for (int index = _configuration.HasHeader ? 1 : 0; index < data.Count; index++)
			{
				if(forward)
				{
					sortIndex = double.Parse(data[index].Item1) + Math.Log10(double.Parse(data[index].Item2)) / 10 + Math.Log10(double.Parse(data[index].Item3)) / 100;
				}
				else
				{
					sortIndex = double.Parse(data[index].Item2) + Math.Log10(double.Parse(data[index].Item1)) / 10 + Math.Log10(double.Parse(data[index].Item3)) / 100;
				}

				indexed.Add(new Tuple<double, string, string, string>(sortIndex, data[index].Item1, data[index].Item2, data[index].Item3));
			}

			return indexed;
		}
	}
}
