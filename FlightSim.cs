using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace FlightSim
{
    class FlightSim
    {
        private List<Dispatcher> dispatchers;
        private int totalPenalty;
        private bool IsSpeedGained;
        private bool IsFlyBegin;


        Field field = new Field(120, 33);
        Airplane airplane = new Airplane(20, 30);
        Cloud cloud1 = new Cloud(110, 7, 1);
        Cloud cloud2 = new Cloud(75, 9, 1);
        private int CurrentDistance;
        
        public FlightSim()
        {

            dispatchers = new List<Dispatcher>();
            CurrentDistance = 0;
            totalPenalty = 0;
            IsSpeedGained = false;
            IsFlyBegin = false;
           
        }

        

        public void AddDispatcher(string name)
        {
            Dispatcher d = new Dispatcher(name);
            
            dispatchers.Add(d);
            WriteLine($"Диспетчер {name} добавлен!\a");
        }


        public void Fly()
        {

            WriteLine("Перед полетом добавьте диспетчеров.");
            WriteLine($"\nВведите имя первого диспетчера: ");
            AddDispatcher(ReadLine());
            WriteLine($"\nВведите имя второго диспетчера: ");
            AddDispatcher(ReadLine());
            airplane.ChangeEvent += dispatchers[0].DispatcherRecommendations;
            Console.Clear();
            SetCursorPosition((field.Width + 3), 4);
            WriteLine("Управление:");
            SetCursorPosition((field.Width + 3), 5);
            WriteLine("RightArrow - увеличить скорость самолета на 50,");
            SetCursorPosition((field.Width + 3), 6);
            WriteLine("LeftArrow - уменьшить скорость самолета на 50,");
            SetCursorPosition((field.Width + 3), 7);
            WriteLine("Shift + RightArrow - увеличить скорость самолета на 150,");
            SetCursorPosition((field.Width + 3), 8);
            WriteLine("Shift + LeftArrow - уменьшить скорость самолета на 150,");
            SetCursorPosition((field.Width + 3), 9);
            WriteLine("UpArrow - увеличить высоту самолета на 250,");
            SetCursorPosition((field.Width + 3), 10);
            WriteLine("DownArrow - уменьшить высоту самолета на 250,");
            SetCursorPosition((field.Width + 3), 11);
            WriteLine("Shift + UpArrow - увеличить высоту самолета на 500,");
            SetCursorPosition((field.Width + 3), 12);
            WriteLine("Shift + DownArrow - уменьшить высоту самолета на 500.");

            Task task1 = new Task(() => cloud1.Move());
            Task task2 = new Task(() => cloud2.Move());
            Task task3 = new Task(() => Animation.Draw(airplane));
            field.Draw();
            task1.Start();
            task2.Start();
            task3.Start();

            ConsoleKeyInfo key;

            while (true)
            {
                Animation.DrawGround();
               
                key = Console.ReadKey();

                if (airplane.CurrentSpeed < 1001)
                {
                    Animation.ShowMessage("                                                     ", 1, 47);
                   
                }
                if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
                {
                    if (key.Key == ConsoleKey.RightArrow) airplane.CurrentSpeed += 150;
                    else if (key.Key == ConsoleKey.LeftArrow) airplane.CurrentSpeed -= 150;
                    else if (key.Key == ConsoleKey.UpArrow) airplane.CurrentHeight += 500;
                    else if (key.Key == ConsoleKey.DownArrow) airplane.CurrentHeight -= 500;
                }
                else
                {
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        airplane.CurrentSpeed += 50;
                        cloud1.Speed++;
                        cloud2.Speed++;
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        airplane.CurrentSpeed -= 50;
                        cloud1.Speed--;
                        cloud2.Speed--;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        airplane.CurrentHeight += 250;
                        Animation.Up(airplane);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        airplane.CurrentHeight -= 250;
                        Animation.Down(airplane);
                    }


                }
                if (dispatchers.Count >= 2 && airplane.CurrentSpeed >= 50)
                {
                    if (!IsFlyBegin)
                    {
                        Animation.ShowMessage("Полет начался!", 1, field.Height + 4);
                        
                    }
                    IsFlyBegin = true;
                    if (airplane.CurrentSpeed > 0 && airplane.CurrentSpeed < 250)
                        CurrentDistance++;
                    else if (airplane.CurrentSpeed >= 250 && airplane.CurrentSpeed < 500)
                        CurrentDistance+=2;
                    else if (airplane.CurrentSpeed >= 500 && airplane.CurrentSpeed < 750)
                        CurrentDistance+=3;
                    else if (airplane.CurrentSpeed >= 750)
                        CurrentDistance += 4;
                 
                    
                    
                    if (airplane.CurrentSpeed == 1000)
                    {
                        if (!IsSpeedGained)
                        {
                            Animation.ShowMessage("Вы набрали максимальную скорость. Теперь ваша задача пролететь 20 км и посадить самолет!", 1, field.Height + 4);
                           
                        }
                        IsSpeedGained = true;
                        airplane.ChangeEvent -= dispatchers[0].DispatcherRecommendations;
                        airplane.ChangeEvent += dispatchers[1].DispatcherRecommendations;
                       
                    }
                    else if (IsSpeedGained && airplane.CurrentSpeed <= 50 && airplane.CurrentHeight == 0)
                    {
                        Animation.ShowMessage("Полет закончился!                                                                                    ", 1, field.Height + 4);
                     
                        foreach (Dispatcher i in dispatchers)
                        {
                            totalPenalty += i.Penalty;
                        }
                        Animation.ShowMessage($"Штрафные очки диспетчера {dispatchers[0].Name}: {dispatchers[0].Penalty}", 1, field.Height + 5);
                        Animation.ShowMessage($"Штрафные очки диспетчера {dispatchers[1].Name}: {dispatchers[1].Penalty}", 1, field.Height + 6);

                        Animation.ShowMessage($"Сумарное число штрафных очков: {totalPenalty}", 1, field.Height + 7);
                        break;
                    }
                }
                Animation.ShowMessage($"Скорость: {airplane.CurrentSpeed} км/ч Высота: {airplane.CurrentHeight} м Расстояние: {CurrentDistance}", (field.Width / 2) - 25, field.Height + 2);
               
            }
        }
    }
}
