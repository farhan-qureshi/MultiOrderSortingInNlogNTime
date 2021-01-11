using System;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	interface ISortingProvider
	{
		IList<Tuple<string, string, string>> Sort(IList<Tuple<string, string, string>> data, bool direction);
	}
}
