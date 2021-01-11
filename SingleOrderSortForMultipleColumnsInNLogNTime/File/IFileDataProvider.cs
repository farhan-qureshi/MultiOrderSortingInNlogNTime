using System;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	interface IFileDataProvider
	{
		string[] Read();
		void WriteWithTimespanThenDatasetOrder(IList<Tuple<string, string, string>> content);
		void WriteWithDatasetThenTimespanOrder(IList<Tuple<string, string, string>> content);
	}
}
