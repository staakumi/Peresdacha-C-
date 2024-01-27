using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Zmeya
    {
        public int[,] zmeyka = new int[3, 2];
        public Zmeya() //конструктор по умолчанию выставляет координаты трех элементов змейки
        {
            for (int i = 0; i < 3; i++)
            {

                zmeyka[i, 0] = -i;
                zmeyka[i, 1] = 0;

            }

        }
        public void SnakeErase(int x, int y) //стирание змейки
        {
            for (int i = 0; i < zmeyka.GetLength(0); i++)
            {

                Console.SetCursorPosition(x + zmeyka[i, 0], y + zmeyka[i, 1]);

                Console.Write(" ");
            }
        }
        public void DrawSnake(int x, int y) //рисовать змейку
        {
            for (int i = 0; i < zmeyka.GetLength(0); i++)
            {
               

                Console.SetCursorPosition(x + zmeyka[i, 0], y + zmeyka[i, 1]);
               if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
               else Console.ForegroundColor = ConsoleColor.Green;


                Console.Write('O');


            }

            
            
            
            
        }
        public void SnakeMove(int[] direction) //движение змейки
        {
            for (int i = zmeyka.GetLength(0)-1; i > 0; i--) //во первых цикл идет с предпоследнего элемента по первый
            {
                zmeyka[i, 0] = zmeyka[i-1, 0] - direction[0];
                zmeyka[i, 1] = zmeyka[i-1, 1] - direction[1]; //сдвинул все элементы в зад
            }
            zmeyka[1, 0] = -direction[0];
            zmeyka[1, 1] = -direction[1]; //сдвиг. Не координаты!
        }
        public void SnakeGrowing()//увеличивает длину змеюки
        {
            int[,] tempArray = new int[zmeyka.GetLength(0) + 1, 2];
             
            for (int i = 0; i < zmeyka.GetLength(0); i++)
            {
                tempArray[i, 0] = zmeyka[i, 0];
                tempArray[i, 1] = zmeyka[i, 1];

            }
            
                zmeyka = tempArray;
        }

        public void ZmeykaNewLevel()
        {
            int[,] tempArray = new int[3, 2];

            for (int i = 0; i < 3; i++)
            {
                tempArray[i, 0] = zmeyka[i, 0];
                tempArray[i, 1] = zmeyka[i, 1];

            }

            zmeyka = tempArray;
        }
        public bool SnakeBarier()
        {
            
            bool temp = false;
            for (int i = 1; i < zmeyka.GetLength(0); i++)
            {
                if (zmeyka[i, 0] == 0 && zmeyka[i, 1] == 0)
                {
                    temp = true;
                }
                
            }
            return temp;
        }
    }
}
