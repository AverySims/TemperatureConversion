namespace TempConvert
{
	internal class Program
	{
		// array that lists all selectable conversion methods
		// set to "readonly" so it cannot be "accidentally" modified at runtime
		private static readonly string[] convertType = { "Celsius to Fahrenheit", "Fahrenheit to Celsius", "Celsius to Kelvin", "Kelvin to Celsius", "Fahrenheit to Kelvin", "Kelvin to Fahrenheit" };

		// user imput for selecting conversion method
		public static int convertSelectVal = -1;
		// user input for starting temerature in conversion
		public static double temperatureInputVal = 0.0;
		// user input for setting program end behaviour
		public static int endStateVal = -1;

		private static bool enableMainLoop = true;
		private static bool enableSelectionLoop = true;
		private static bool enableEndingLoop = true;

		static void Main(string[] args)
		{
			while (enableMainLoop)
			{
				PrintConversionMethods();
				SelectConversionMethod();
				SelectEndingPath();
			}
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

		#region Parsing
		// EC = Error correction
		private static bool ParseIntEC(out int val)
		{
			return int.TryParse(Console.ReadLine(), out val);
		}

		private static bool ParseDoubleEC(out double val)
		{
			return double.TryParse(Console.ReadLine(), out val);
		}
		#endregion

		private static void PrintConversionMethods()
		{
			// adding empty line before loop
			Console.WriteLine("Select your conversion,");
			PrintBlank();

			for (int i = 0; i < convertType.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {convertType[i]}");
				// 1. Celsius to Fahrenheit
				// 2. Fahrenheit to Celsius
				// etc...

			}
		}

		private static void SelectConversionMethod()
		{
			// reset loop state before entering loop
			enableSelectionLoop = true;

			while (enableSelectionLoop)
			{
				// reading input with "TryParse" functions to prevent
				// crashing when an unexpected variable type is used
				ParseIntEC(out convertSelectVal);
				PrintBlank();

				if (DetermineSelectionValidity(convertSelectVal))
				{
					Console.WriteLine("Selected: " + convertType[convertSelectVal - 1]);
					enableSelectionLoop = false;
				}
				else
				{
					PrintInvalidSelection();
				}
			}

			Console.WriteLine("Please input your temperature:");

			// reading user input before switch
			ParseDoubleEC(out temperatureInputVal);
			PrintBlank();

			switch (convertSelectVal)
			{
				case 1: // Celsius to Fahrenheit
					Console.WriteLine( PrintFromCelsius( FormatCelsius( temperatureInputVal ) ) );
					Console.WriteLine( PrintToFahrenheit( FormatFahrenheit(CelsiusToFahrenheit( temperatureInputVal ) ) ) );
					break;

				case 2: // Fahrenheit to Celsius
					Console.WriteLine( PrintFromFahrenheit( FormatFahrenheit( temperatureInputVal ) ) );
					Console.WriteLine( PrintToCelsius( FormatCelsius( FahrenheitToCelsius( temperatureInputVal ) ) ) );
					break;

				case 3: // Celsius to Kelvin
					Console.WriteLine( PrintFromCelsius( FormatCelsius( temperatureInputVal ) ) );
					Console.WriteLine( PrintToKelvin( FormatKelvin( CelsiusToKelvin( temperatureInputVal ) ) ) );
					break;

				case 4: // Kelvin to Celsius
					Console.WriteLine( PrintFromKelvin( FormatKelvin( temperatureInputVal ) ) );
					Console.WriteLine( PrintToCelsius( FormatCelsius( KelvinToCelsius( temperatureInputVal ) ) ) );
					break;

				case 5: // Fahrenheit to Kelvin
					Console.WriteLine( PrintFromFahrenheit( FormatFahrenheit( temperatureInputVal ) ) );
					Console.WriteLine( PrintToKelvin( FormatKelvin( FahrenheitToKelvin( temperatureInputVal ) ) ) );
					break;

				case 6: // Kelvin to Fahrenheit
					Console.WriteLine( PrintFromKelvin( FormatKelvin( temperatureInputVal ) ) );
					Console.WriteLine( PrintToFahrenheit( FormatFahrenheit( KelvinToFahrenheit( temperatureInputVal ) ) ) );
					break;
			}
		}

		private static void SelectEndingPath()
		{
			// reset loop state before entering loop
			enableEndingLoop = true;
			Console.WriteLine("Choose what happens next:");
			PrintBlank();

			Console.WriteLine("1. Convert new temperature");
			Console.WriteLine("2. Quit program");

			while (enableEndingLoop)
			{
				ParseIntEC(out endStateVal);
				switch (endStateVal)
				{
					case 1:
						enableEndingLoop = false;
						break;

					case 2:
						enableEndingLoop = false;
						enableMainLoop = false;
						break;

					default:
						PrintInvalidSelection();
						break;
				}
			}
			PrintBlank();
			return;
		}

		private static bool DetermineSelectionValidity(int val)
		{
			return val > 0 && val <= convertType.Length;
		}

		private static void PrintBlank()
		{
			Console.WriteLine("");
		}

		private static void PrintInvalidSelection()
		{
			Console.WriteLine("Invalid selection, please select a listed option.");
		}
	}
}