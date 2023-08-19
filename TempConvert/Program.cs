using System.ComponentModel.Design;

namespace TempConvert
{
	internal class Program
	{
		// array that lists all selectable conversion methods
		private static string[] convertType = { "Celsius to Fahrenheit", "Fahrenheit to Celsius", "Celsius to Kelvin", "Kelvin to Celsius", "Fahrenheit to Kelvin", "Kelvin to Fahrenheit" };

		// user imput for selecting conversion method
		private static int convertSelectVal = -1;

		// user input for starting temerature in conversion
		private static double temperatureInputVal = 0.0;

		private static bool enableSelectionLoop = true;

		// meant for running the program multiple times
		private static bool enableMainLoop = true;
		

		static void Main(string[] args)
		{
			while (enableMainLoop)
			{
				PrintConversionMethods();

				SelectConversionMethod();
			}
			
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
				// 2. Fahrenheit to Celsius
				// etc...
				Console.WriteLine(i + 1 + ". " + convertType[i]);
			}

			// adding empty line after loop
			// Writing "\n" causes a print of two lines, so stick with " " instead
			Console.WriteLine(" ");
		}

		private static void SelectConversionMethod()
		{
			// reset loop state before entering loop
			enableSelectionLoop = true;

			while (enableSelectionLoop)
			{
				// parsing the user input with error correction for invalid inputs
				ParseIntEC(out convertSelectVal);

				if (DetermineSelectionValidity(convertSelectVal))
				{
					Console.WriteLine("\n" + "Selected: " + convertType[convertSelectVal - 1]);
					enableSelectionLoop = false;
				}
				else
				{
					Console.WriteLine("\n" + "Invalid selection, please select a listed conversion method");
				}
			}

			switch (convertSelectVal)
			{
				case 2:
					Console.WriteLine("\n" + "Please input your temperature:");

					ParseDoubleEC(out temperatureInputVal);

					Console.WriteLine("\n" + "Fahrenheit: " + temperatureInputVal + "°F" + "\n" + "Celsius: " + FahrenheitToCelsius(temperatureInputVal) + "°C");

					break;
			}

		}

		private static bool DetermineSelectionValidity(int val)
		{
			return val > 0 && val <= convertType.Length;
		}

		// EC = Error correction
		private static bool ParseIntEC(out int val)
		{
			return int.TryParse(Console.ReadLine(), out val);
		}

		private static bool ParseDoubleEC(out double val)
		{
			return double.TryParse(Console.ReadLine(), out val);
		}

	}
}