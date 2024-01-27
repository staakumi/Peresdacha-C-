using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int CurentX = 4;
            int CurentY = 4;
            int food = 10;
            int[] direction = { 0, 1 };
            int delta = 0;
            int score = 0;
            bool trigger = true;
            string file = "C:\\Users\\Sasha\\Desktop\\Score.txt";
            int speed = 300;
            int level = 1;
            int oldLevel;
            int FoodCount;
            int record;


            Thread thread = new Thread(_ =>
            {
                while (trigger)
                {

                    direction = KeyMove(direction);
                }
            });
            thread.Start();

            Pole square = new Pole();
            Zmeya snake = new Zmeya();

            

            record = Convert.ToInt32(File.ReadAllLines(file)[0]);

            while (trigger)     //НАЧАЛО УРОВНЯ
            {
                FoodCount = food;
                square.MapSize();// заполняет массив поля
                snake.ZmeykaNewLevel();
                square.RandomFood(food); // раскидали еду
                square.PrintMap();//рисуется поле
                oldLevel = level; //Эта переменная нужна для перехода на следующий уровень
                ConsoleColor snakecolor = Console.ForegroundColor;


                while (trigger && level == oldLevel)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    snake.DrawSnake(CurentX, CurentY);  // рисуем змейку               
                    Console.ForegroundColor = snakecolor;
                    Thread.Sleep(speed);                  // пауза
                    snake.SnakeErase(CurentX, CurentY); // стираем змейку

                    CurentX += direction[0];  // приращение текущих позиций из паралельного потока
                    CurentY += direction[1];
                    delta = square.GrowCount(CurentX, CurentY); // Дельта равна единице если змеюка съела еду
                    if (delta == 1)
                    {
                        snake.SnakeGrowing();
                    }
                    snake.SnakeMove(direction);  // пересчет змейки на следующий ход

                    if (snake.SnakeBarier())
                    {
                        trigger = false;
                    }
                    score += delta * level; // считаем количество еды
                    if (score > record) record = score;
                    FoodCount -= delta;
                    if (FoodCount == 0)
                    {
                        level++;
                    }
                    square.Score(score, level, record);


                    if (square.GameOver(CurentX, CurentY))
                    {
                        trigger = false;
                    }


                    square.SnakeSound(CurentX, CurentY);

                }
                if (!trigger)
                {
                    Console.Clear();
                    Console.WriteLine(" GAME OVER");
                    //thread.Join();
                    NewRecord(score, file, record);
                }
                else NewLevel(ref speed, ref food);

            }

        }
        static int[] KeyMove(int[] oldDirection)
        {
            int x = 0;
            int y = 0;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {

                case ConsoleKey.UpArrow:

                    if (oldDirection[1] != 1)
                    {

                        --y;
                    }
                    else
                    {
                        ++y;
                    }



                    break;
                case ConsoleKey.DownArrow:

                    if (oldDirection[1] != -1)
                    {

                        ++y;
                    }
                    else
                    {
                        --y;
                    }


                    break;
                case ConsoleKey.LeftArrow:

                    if (oldDirection[0] != 1)
                    {

                        --x;
                    }
                    else
                    {
                        ++x;
                    }


                    break;
                case ConsoleKey.RightArrow:

                    if (oldDirection[0] != -1)
                    {
                    ++x;

                    }
                    else
                    {
                        --x;
                    }

                    break;
                
            }
            int[] direction1 = new int[] { x, y };
            return direction1;
        }// метод считывания стрелок для движения змеюки

        static void NewLevel(ref int speed, ref int food)
        {

            speed -= 30;
            food += 5;
        }
        static void NewRecord(int score, string file, int record)
        {

            if (!File.Exists(file))
            {
                File.Create(file);
            }
            if (score >= record)
            {

                File.WriteAllText(file, Convert.ToString(score));

            }

        }
    }
}
