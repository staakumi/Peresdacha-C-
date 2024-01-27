using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Threading;

namespace Snake
{


    internal class Pole
    {
        public int MaxX;
        public int MaxY;
        //static string path = "map.txt";

        char[,] map = null;




        public void MapSize()
        {
            string path = "map.txt";
            string[] file = File.ReadAllLines(path);
            MaxX = file.Length;
            MaxY = file[0].Length;
            map = new char[MaxX, MaxY];

            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                    map[i, j] = file[i][j];
                }
            }
        }
        public void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void RandomFood(int food)
        {
            Random rand = new Random();
            for (int i = 0; i < food; i++)
            {
                map[rand.Next(1, MaxX - 1), rand.Next(1, MaxY - 1)] = '*';
                
            }
        }
        public int GrowCount(int x, int y)
        {
            if (map[y, x] == '*')
            {
                return 1;
            }
            else return 0;
        }

        public void Score(int score, int level, int record)
        {
            Console.SetCursorPosition(33, 2);
            Console.Write($"Ваш действующий рекорд {record}");
            Console.SetCursorPosition(33, 0);
            Console.Write($"Счет: {score}");
            Console.SetCursorPosition(33, 1);
            Console.Write($"Уровень: {level}");
        }

        public bool GameOver(int x , int y)
        {
            if (x<=0 || x >= MaxY-1 || y<=0 || y >= MaxX-1 )
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public void SnakeSound(int x, int y)
        {
            if (map[y, x] == '*')
            {
                Thread threadSound = new Thread(_ =>
                {
                Console.Beep(600, 300);
                });
                threadSound.Start();
                map[y, x] = ' ';
            }
        }
        
        
    }

}







