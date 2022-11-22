using System;
using static System.Console;

namespace FlightSim
{
	
	class Dispatcher
	{
		public string Name { get; set; }
		public int Penalty { get; set; }
		private int adjustment;
		private static Random r;
		//private int start;
		//private int finish;
		public Dispatcher(string name)
		{
			Name = name;
			r = new Random();
			adjustment = r.Next(-200, 200);
			Penalty = 0;
		}
		
		public void DispatcherRecommendations(int speed, int height)
		{
			int recomended = 7 * speed - adjustment;

			int difference;
			if (height > recomended)
				difference = height - recomended;
			else
				difference = recomended - height;
			Animation.ShowMessage($"Диспетчер {Name}: Рекомендуемая высота полета: {recomended} м.", 1, 45);
		

			if (speed > 1000)
			{
				Penalty += 100;
				Animation.ShowMessage($"Диспетчер {Name}: Немедленно снизьте скорость!", 1, 47);
				
				
			}

			if (difference >= 300 && difference < 600) Penalty += 25;
			else if (difference >= 600 && difference < 1000) Penalty += 50;
			else if (difference >= 1000 || (speed <= 0 && height <= 0))
				throw new AirplaneCrushed("Самолет разбился");

			if (Penalty >= 1000)
				throw new Unsuitable("Непригоден к полетам");
		}
	}
}
