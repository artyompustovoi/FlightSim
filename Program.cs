using System;
using System.Threading.Tasks;
using static System.Console;
namespace FlightSim
{
	class AirplaneCrushed : Exception
	{
		public AirplaneCrushed(string message)
			: base(message)
		{ }
	}
	class Unsuitable : Exception
	{
		public Unsuitable(string message)
			: base(message)
		{ }
	}

	class Program
	{
		static void Main(string[] args)
		{
           
			
			try
			{
				FlightSim flightSim = new FlightSim();
                flightSim.Fly();
				
			}
			catch (AirplaneCrushed ac)
			{

				SetCursorPosition(1, 39);
				WriteLine(ac.Message);
				
			}
			catch (Unsuitable u)
			{
				SetCursorPosition(1, 39);
				WriteLine(u.Message);
				
			}

		}
	}
}
