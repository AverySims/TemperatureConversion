/*
 * This is a standalone class that holds 'common' functions that are used
 * to make console applications more lightweight and less bloated
 */

namespace TempConvert
{
	internal class SimpleConsoleFunctions
	{
		#region Parsing
		// EC = Error correction
		public static bool ParseIntEC(out int val)
		{
			return int.TryParse(Console.ReadLine(), out val);
		}

		public static bool ParseDoubleEC(out double val)
		{
			return double.TryParse(Console.ReadLine(), out val);
		}
		#endregion

		public static void PrintBlank()
		{
			Console.WriteLine("");
		}

		public static void PrintInvalidSelection()
		{
			Console.WriteLine("Invalid selection, please select a listed option.");
		}
	}
}