using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FlightSim
{
    public class Field
    {
        public int Height { get; set; }
        public int Width { get; set; }
       
        public Field(int width, int height)
        {
            Height = height;
            Width = width;
        }
        public void Draw()
        {
            
            for (int i = 0; i <= Width; i++)
            {
                SetCursorPosition(i, 0);
                Write("─");
            }
            
            
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i <= Width; i++)
            {
                SetCursorPosition(i, Height + 1);
                Write("─");
            }
            for (int i = 0; i <= Height; i++)
            {
                SetCursorPosition(0, i);
                Write("│");
            }
            for (int i = 0; i <= Height; i++)
            {
                SetCursorPosition(Width + 1, i);
                Write("│");
            }
            SetCursorPosition(0, 0);
            Write("┌");
            SetCursorPosition(Width + 1, 0);
            Write("┐");
            SetCursorPosition(0, Height + 1);
            Write("└");
            SetCursorPosition(Width + 1, Height + 1);
            Write("┘");
        }
    }

}
