using System;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Extension
{
	public static class ListExtensions
	{
		public static string[] ToStringArray(this IList<Tuple<string, string, string>> list)
		{
			string[] arrayString = new string[list.Count]; 
			for (int arrayIndex = 0; arrayIndex < list.Count; arrayIndex++)
			{
				arrayString[arrayIndex] = $"{list[arrayIndex].Item1}, {list[arrayIndex].Item2}, {list[arrayIndex].Item3}";
			}

			return arrayString;
		}
	}
}
