using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace FlightSim
{
    class Cloud
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        
        private static object obj = new object();

        public Cloud(int x, int y, int speed)
        {
            X = x;
            Y = y;
            Speed = speed;
        }
       
        
        public void Move()
        {
            while (true)
            {

                Animation.EraseCloud(this, "\0");
                X--;
                Animation.DrawCloud(this);
                if (X == 1)
                {
                    Animation.EraseCloud(this, "\0");
                    X = 110;
                }
                Thread.Sleep(1000 / Speed);

            }
        }
    }
}
