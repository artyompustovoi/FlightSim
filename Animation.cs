using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace FlightSim
{

    class Animation
    {
        private static object obj = new object();
        public static void DrawGround()
        {
            lock (obj)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                for (int i = 1; i <= 119; i++)
                {
                    SetCursorPosition(i, 31);
                    Write("_");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public static void ShowMessage(string message, int x, int y)
        {
            lock (obj)
            {
                SetCursorPosition(x, y);
                Write(message);
            }
        }

        public static void DrawCloud(Cloud cloud)
        {
            lock (obj)
            {
                for (int i = 0; i < 9; i++)
                {
                    SetCursorPosition(cloud.X + i, cloud.Y);
                    Write("@");
                }
                SetCursorPosition(cloud.X + 2, cloud.Y - 1);
                Write("@");
                SetCursorPosition(cloud.X + 3, cloud.Y - 1);
                Write("@");
                SetCursorPosition(cloud.X + 4, cloud.Y - 1);
                Write("@");
                SetCursorPosition(cloud.X + 7, cloud.Y - 1);
                Write("@");
            }
        }
        public static void EraseCloud(Cloud cloud, string str)
        {
            lock (obj)
            {
                for (int i = 0; i < 9; i++)
                {
                    SetCursorPosition(cloud.X + i, cloud.Y);
                    Write(str);
                }
                SetCursorPosition(cloud.X + 2, cloud.Y - 1);
                Write(str);
                SetCursorPosition(cloud.X + 3, cloud.Y - 1);
                Write(str);
                SetCursorPosition(cloud.X + 4, cloud.Y - 1);
                Write(str);
                SetCursorPosition(cloud.X + 7, cloud.Y - 1);
                Write(str);
            }

        }

        public static void DrawAirplane(Airplane airplane)
        {

            int X = airplane.X;
            int Y = airplane.Y;
            Console.ForegroundColor = ConsoleColor.Red;
            SetCursorPosition(X, Y);
            Write("|");
            SetCursorPosition(X + 1, Y);
            Write("\\");
            SetCursorPosition(X + 2, Y);
            Write("_");
            SetCursorPosition(X + 3, Y);
            Write("_");
            SetCursorPosition(X + 4, Y);
            Write("_");
            SetCursorPosition(X + 5, Y);
            Write("_");
            SetCursorPosition(X + 6, Y);
            Write("_");
            SetCursorPosition(X + 7, Y);
            Write("|");
            SetCursorPosition(X + 8, Y);
            Write("_");
            SetCursorPosition(X + 9, Y);
            Write("\\");
            SetCursorPosition(X + 10, Y);
            Write("_");
            SetCursorPosition(X + 11, Y);
            Write("_");
            SetCursorPosition(X + 12, Y);
            Write("_");
            SetCursorPosition(X + 13, Y);
            Write("_");
            SetCursorPosition(X + 14, Y);
            Write("_");
            SetCursorPosition(X + 15, Y);
            Write("_");

            SetCursorPosition(X + 7, Y - 1);
            Write("|");
            SetCursorPosition(X + 8, Y - 1);
            Write("\\");

            SetCursorPosition(X, Y + 1);
            Write("\\");
            for (int i = 1; i < 17; i++)
            {
                SetCursorPosition(X + i, Y + 1);
                Write("_");
            }
            SetCursorPosition(X + 17, Y + 1);
            Write(")");

            SetCursorPosition(X + 7, Y + 2);
            Write("|");
            SetCursorPosition(X + 9, Y + 2);
            Write("/");

            SetCursorPosition(X + 7, Y + 3);
            Write("|");
            SetCursorPosition(X + 8, Y + 3);
            Write("/");


            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void Up(Airplane airplane)
        {
            lock (obj)
            {
                Animation.Erase(airplane, "\0");
                airplane.Y--;
                Animation.DrawAirplane(airplane);
            }
        }
        public static void Down(Airplane airplane)
        {
            lock (obj)
            {
                Animation.Erase(airplane, "\0");
                airplane.Y++;
                Animation.DrawAirplane(airplane);
            }
        }
        public static void Draw(Airplane airplane)
        {
            while (true)
            {
                lock (obj)
                {
                    DrawAirplane(airplane);


                }
                Thread.Sleep(100);
            }
        }
        public static void Erase(Airplane airplane, string str)
        {
           
                int X = airplane.X;
                int Y = airplane.Y;


                SetCursorPosition(X, Y);
                Write(str);
                SetCursorPosition(X + 1, Y);
                Write(str);
                SetCursorPosition(X + 2, Y);
                Write(str);
                SetCursorPosition(X + 3, Y);
                Write(str);
                SetCursorPosition(X + 4, Y);
                Write(str);
                SetCursorPosition(X + 5, Y);
                Write(str);
                SetCursorPosition(X + 6, Y);
                Write(str);
                SetCursorPosition(X + 7, Y);
                Write(str);
                SetCursorPosition(X + 8, Y);
                Write(str);
                SetCursorPosition(X + 9, Y);
                Write(str);
                SetCursorPosition(X + 10, Y);
                Write(str);
                SetCursorPosition(X + 11, Y);
                Write(str);
                SetCursorPosition(X + 12, Y);
                Write(str);
                SetCursorPosition(X + 13, Y);
                Write(str);
                SetCursorPosition(X + 14, Y);
                Write(str);
                SetCursorPosition(X + 15, Y);
                Write(str);

                SetCursorPosition(X + 7, Y - 1);
                Write(str);
                SetCursorPosition(X + 8, Y - 1);
                Write(str);

                SetCursorPosition(X, Y + 1);
                Write(str);
                for (int i = 1; i < 17; i++)
                {
                    SetCursorPosition(X + i, Y + 1);
                    Write(str);
                }
                SetCursorPosition(X + 17, Y + 1);
                Write(str);

                SetCursorPosition(X + 7, Y + 2);
                Write(str);
                SetCursorPosition(X + 9, Y + 2);
                Write(str);

                SetCursorPosition(X + 7, Y + 3);
                Write(str);
                SetCursorPosition(X + 8, Y + 3);
                Write(str);



        }

    }

}
