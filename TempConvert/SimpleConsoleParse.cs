using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConvert
{
	internal class SimpleConsoleParse
	{

		public static bool ParseIntEC(out int val)
		{
			return int.TryParse(Console.ReadLine(), out val);
		}

		public static bool ParseDoubleEC(out double val)
		{
			return double.TryParse(Console.ReadLine(), out val);
		}

	}
}
