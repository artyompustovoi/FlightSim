using System;
using System.Collections.Generic;
using static System.Console;
namespace FlightSim
{
	
	class Airplane
	{
        public delegate void ChangeDelegate(int speed, int height);
        public event ChangeDelegate ChangeEvent;

      

       
        private int currentSpeed;

        public int CurrentSpeed
        {
            get { return currentSpeed; }
            set
            { 
                currentSpeed = value;
                ChangeEvent(CurrentSpeed, CurrentHeight);
            }
        }

        private int сurrentnHeight;

        public int СurrentnHeight
        {
            get { return сurrentnHeight; }
            set { сurrentnHeight = value; }
        }


        public int CurrentHeight;
       
       
        
        public int X { get; set; }
        public int Y { get; set; }
       
        


       
        public Airplane(int x, int y)
        {
            X = x;
            Y = y;
            
            currentSpeed = 0;
            CurrentHeight = 0;
            
           
        }
        
       
       
    }
}
