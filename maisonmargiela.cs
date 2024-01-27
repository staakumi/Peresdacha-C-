using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICHESKAYA_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choise;
            bool x = true;
            while(x) 
            { 

            Console.WriteLine("выберите программу:");
            Console.WriteLine("1. Игра угадай число");
            Console.WriteLine("2. Таблица умножения");
            Console.WriteLine("3. Вывод делителей числа");
            Console.WriteLine("4. Выйти из программы");
            choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        int lower = 0;
                        int higher = 100;
                        int choise1;
                        int trying = 1;
                        Random rand = new Random();
                        int number = rand.Next(lower, higher + 1);

                        Console.WriteLine($"Загадано число от {lower} до {higher}. Попробуй его отгаддать");

                        while (true)
                        {
                            choise1 = Convert.ToInt32(Console.ReadLine());
                            if (choise1 == number)
                            {
                                Console.WriteLine($"Вы угадали число за {trying} попыток");
                                break;
                            }
                            else if (choise1 > number)
                            {
                                Console.WriteLine("Число меньше");
                            }
                            else if (choise1 < number)
                            {
                                Console.WriteLine("Число больше ");
                            }
                            trying++;
                        }
                        break;
                    case 2:
                        int[,] multiply = new int[9, 9];

                        for (int k = 0; k < multiply.GetLength(0); k++)
                        {
                            multiply[k, 0] = k + 1;
                        }
                        for (int k = 0; k < multiply.GetLength(1); k++)
                        {
                            multiply[0, k] = k + 1;
                        } // пустая таблица умножения готова

                        for (int i = 0; i < multiply.GetLength(0); i++)
                        {
                            for (int j = 0; j < multiply.GetLength(1); j++)
                            {
                                if (j != 0 || i != 0) ;
                                {
                                    multiply[j, i] = (i + 1) * (j + 1);

                                }
                                Console.Write(multiply[j, i] + "\t");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        int a;

                        Console.WriteLine("Введите число");
                        a = Convert.ToInt32(Console.ReadLine());


                        for (int i = a; i != 0; i--)
                        {
                            if (a % i == 0)
                            {
                                Console.Write(i + " ");
                            }
                        }
                        break;
                    case 4:
                        x = false;
                        break;
                   
                }
            }
        }
    }
}
