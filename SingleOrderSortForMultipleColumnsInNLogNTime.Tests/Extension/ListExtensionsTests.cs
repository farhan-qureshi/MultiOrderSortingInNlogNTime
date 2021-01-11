using NUnit.Framework;
using System;
using System.Collections.Generic;
using SingleOrderSortForMultipleColumnsInNLogNTime.Extension;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.Extension
{
	[TestFixture]
	public class ListExtensionsTests
	{
		[Test]
		public void ToStringArray_Transfers_All_Data_From_List_To_StringArray()
		{
			var list = new List<Tuple<string, string, string>>();
			string[] values = { "1.1", "1.2", "1.3", "2.1", "2.2", "2.3" };
			var t1 = new Tuple<string, string, string>(values[0], values[1], values[2]);
			list.Add(t1);

			var t2 = new Tuple<string, string, string>(values[3], values[4], values[5]);
			list.Add(t2);

			var stringArray = list.ToStringArray();

			Assert.Contains($"{values[0]}, {values[1]}, {values[2]}", stringArray);
			Assert.Contains($"{values[3]}, {values[4]}, {values[5]}", stringArray);
		}
	}
}
