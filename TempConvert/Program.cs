using System.ComponentModel.Design;

namespace TempConvert
{
	internal class Program
	{
		// array that lists all selectable conversion methods
		private static string[] convertType = { "Celsius to Fahrenheit", "Fahrenheit to Celsius", "Celsius to Kelvin", "Kelvin to Celsius", "Fahrenheit to Kelvin", "Kelvin to Fahrenheit" };

		// user imput for selecting conversion method
		private static int userVal = -1;

		// user input for starting temerature in conversion
		private static double temperatureInputVal = -1.0;

		private static bool shouldLoopSelection = true;



		

		static void Main(string[] args)
		{
			PrintConversionMethods();

			SelectConversionMethod();

		}

		public static double FahrenheitToCelsius(double temperature)
		{
			return (temperature - 32) * 5 / 9;
		}

		private static void PrintConversionMethods()
		{
			// adding empty line before loop
			Console.WriteLine("Select your conversion,\n");

			for (int i = 0; i < convertType.Length; i++)
			{
				// 1. Celsius to Fahrenheit
				// etc...
				Console.WriteLine(i + 1 + ". " + convertType[i]);

			}

			// adding empty line after loop
			Console.WriteLine(" ");
		}

		private static void SelectConversionMethod()
		{
			while (shouldLoopSelection)
			{
				// parsing the user input with error correction for invalid inputs
				int.TryParse(Console.ReadLine(), out userVal);

				if (DetermineSelectionValidity(userVal))
				{
					Console.WriteLine("Selected: " + convertType[userVal - 1]);
					shouldLoopSelection = false;
				}
				else
				{
					Console.WriteLine("Invalid selection, please select a listed conversion");
				}
			}

			switch (userVal)
			{
				case 2:
					Console.WriteLine("Please input your temperature:");

					double.TryParse(Console.ReadLine(), out temperatureInputVal);

					Console.WriteLine("Fahrenheit: " + temperatureInputVal + " degrees"+ "\n" + "Celsius: " + FahrenheitToCelsius(temperatureInputVal) + " degrees");

					break;
			}

		}

		private static bool DetermineSelectionValidity(int val)
		{
			return val > 0 && val <= convertType.Length;
		}

	}
}