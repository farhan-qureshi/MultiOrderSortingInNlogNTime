using System;
using System.Collections.Generic;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	interface ICsvFileDataProcessor 
	{
		IList<Tuple<string, string, string>> ProcessData(string[] data, int numValidColumns, bool hasHeader, Dictionary<int, string> errors);
	}
}
