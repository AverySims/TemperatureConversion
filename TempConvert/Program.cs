


namespace TempConvert
{
	internal class Program
	{
		// array that lists all selectable conversion methods
		// set to "readonly" so it cannot be "accidentally" modified at runtime
		private static readonly string[] convertTypes = { "Celsius to Fahrenheit", "Fahrenheit to Celsius", "Celsius to Kelvin", "Kelvin to Celsius", "Fahrenheit to Kelvin", "Kelvin to Fahrenheit" };

		// user imput for selecting conversion method
		public static int userConvertMethodValue = -1;
		// user input for starting temerature in conversion
		public static double userTemperatureValue = 0.0;

		private static bool loopMain = true;
		private static bool loopConversionSelector = true;

		static void Main(string[] args)
		{
			while (loopMain)
			{
				PrintConversionMethods();
				SelectConversionMethod();
				SimpleConsoleFunctions.SelectEndingAction(out loopMain);
			}
		}

		private static void PrintConversionMethods()
		{
			// adding empty line before loop
			Console.WriteLine("Select your conversion,");
			SimpleConsoleFunctions.PrintBlank();

			for (int i = 0; i < convertTypes.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {convertTypes[i]}");
				// 1. Celsius to Fahrenheit
				// 2. Fahrenheit to Celsius
				// etc...
			}
		}

		private static void SelectConversionMethod()
		{
			// reset loop state before entering loop
			loopConversionSelector = true;

			while (loopConversionSelector)
			{
				// reading input with "TryParse" functions to prevent
				// crashing when an unexpected variable type is used
				SimpleConsoleFunctions.ParseIntEC(out userConvertMethodValue);
				SimpleConsoleFunctions.PrintBlank();

				if (DetermineSelectionValidity(userConvertMethodValue))
				{
					Console.WriteLine("Selected: " + convertTypes[userConvertMethodValue - 1]);
					loopConversionSelector = false;
				}
				else
				{
					SimpleConsoleFunctions.PrintInvalidSelection();
				}
			}

			Console.WriteLine("Please input your temperature:");

			// reading user input before switch
			SimpleConsoleFunctions.ParseDoubleEC(out userTemperatureValue);
			SimpleConsoleFunctions.PrintBlank();

			switch (userConvertMethodValue)
			{
				case 1: // Celsius to Fahrenheit
					Console.WriteLine( PrintFromCelsius( FormatCelsius( userTemperatureValue ) ) );
					Console.WriteLine( PrintToFahrenheit( FormatFahrenheit(CelsiusToFahrenheit( userTemperatureValue ) ) ) );
					break;

				case 2: // Fahrenheit to Celsius
					Console.WriteLine( PrintFromFahrenheit( FormatFahrenheit( userTemperatureValue ) ) );
					Console.WriteLine( PrintToCelsius( FormatCelsius( FahrenheitToCelsius( userTemperatureValue ) ) ) );
					break;

				case 3: // Celsius to Kelvin
					Console.WriteLine( PrintFromCelsius( FormatCelsius( userTemperatureValue ) ) );
					Console.WriteLine( PrintToKelvin( FormatKelvin( CelsiusToKelvin( userTemperatureValue ) ) ) );
					break;

				case 4: // Kelvin to Celsius
					Console.WriteLine( PrintFromKelvin( FormatKelvin( userTemperatureValue ) ) );
					Console.WriteLine( PrintToCelsius( FormatCelsius( KelvinToCelsius( userTemperatureValue ) ) ) );
					break;

				case 5: // Fahrenheit to Kelvin
					Console.WriteLine( PrintFromFahrenheit( FormatFahrenheit( userTemperatureValue ) ) );
					Console.WriteLine( PrintToKelvin( FormatKelvin( FahrenheitToKelvin( userTemperatureValue ) ) ) );
					break;

				case 6: // Kelvin to Fahrenheit
					Console.WriteLine( PrintFromKelvin( FormatKelvin( userTemperatureValue ) ) );
					Console.WriteLine( PrintToFahrenheit( FormatFahrenheit( KelvinToFahrenheit( userTemperatureValue ) ) ) );
					break;
			}
		}

		private static bool DetermineSelectionValidity(int val)
		{
			return val > 0 && val <= convertTypes.Length;
		}

		#region Formatting
		// Fahrenheit
		private static string FormatFahrenheit(double val)
		{
			return $"{val}°F";
		}

		private static string PrintFromFahrenheit(string val)
		{
			return $"From Fahrenheit: {val}";
		}

		private static string PrintToFahrenheit(string val)
		{
			return $"To Fahrenheit: {val}";
		}

		// Celsius
		private static string FormatCelsius(double val)
		{
			return $"{val}°C";
		}

		private static string PrintFromCelsius(string val)
		{
			return $"From Celsius: {val}";
		}

		private static string PrintToCelsius(string val)
		{
			return $"To Celsius: {val}";
		}

		// Kelvin
		private static string FormatKelvin(double val)
		{
			return $"{val} K";
		}

		private static string PrintFromKelvin(string val)
		{
			return $"From Kelvin: {val}";
		}

		private static string PrintToKelvin(string val)
		{
			return $"To Kelvin: {val}";
		}
		#endregion

		#region Conversion
		public static double CelsiusToFahrenheit(double temperature)
		{
			return (temperature * 9 / 5) + 32;
		}

		public static double FahrenheitToCelsius(double temperature)
		{
			return (temperature - 32) * 5 / 9;
		}

		public static double CelsiusToKelvin(double temperature)
		{
			return temperature + 273.15;
		}

		public static double KelvinToCelsius(double temperature)
		{
			return temperature - 273.15;
		}

		public static double FahrenheitToKelvin(double temerature)
		{
			return CelsiusToKelvin(FahrenheitToCelsius(temerature));
		}

		public static double KelvinToFahrenheit(double temperature)
		{
			return CelsiusToFahrenheit(KelvinToCelsius(temperature));
		}
		#endregion
		
	}
}