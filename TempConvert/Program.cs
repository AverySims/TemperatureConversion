namespace TempConvert
{
	internal class Program
	{
		// array that lists all selectable conversion methods
		private static const string[6] conversionTypes = ["Celsius to Fahrenheit",
															"Fahrenheit to Celsius",
															"Celsius to Kelvin",
															"Kelvin to Celsius",
															"Fahrenheit to Kelvin",
															"Kelvin to Fahrenheit"];
		private static void SelectConversionMethod()
		{
			Console.WriteLine("Select your conversion,");

			for (int i = 0; i < conversionTypes.Length; i++)
			{
				Console.WriteLine(conversionTypes[i]);

			}
		}
		
		static void Main(string[] args)
		{
			SelectConversionMethod();

		}
	}
}