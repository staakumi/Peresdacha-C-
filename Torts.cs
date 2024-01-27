using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortiki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool trigger2 = true;
                int Number = 0;

            while (trigger2)
            {

                int Summa = 0;
                bool trigger = true;
                int x = 4; int y = 1;
                Console.CursorVisible = false;
                int pos1;

                string[] Zakaz = new string[] { "", "", "", "", "", "" };

                Fractal Main = new Fractal(new List<string> { "Форма\n", "Размер\n", "Вкус коржей\n", "Количество коржей\n", "Глазурь\n", "Декор\n", "Выйти из программы\n" });
                Fractal Second = new Fractal();
                Main.DrawMenu(x, y, ref Zakaz, Summa);
                Menu menu = new Menu(1, Main.Options.Count); // печатает стрелочное меню
                int pos = menu.ShowArrow(); //Pos - номер строчки возвращаемого меню
                                            //int pos1 = menu.ShowArrow(); //Номер строчки компонентов
                while (trigger)
                {

                    switch (pos)
                    {
                        case 1:
                            Second.Options = new List<string> { "Квадрат - 500", "Круг - 500", "Треугольник - 650", "Сердечко - 700" };

                            break;
                        case 2:
                            Second.Options = new List<string> { "Маленький диаметр  - 1000", "Средний диаметр  - 1500", "Большой диаметр - 2000" };
                            break;
                        case 3:
                            Second.Options = new List<string> { "Шоколадный - 150", "Ванильный - 150", "Клубничный - 150", "Ореховый - 200", "Банановый - 250", "Кокосовый - 300" };
                            break;
                        case 4:
                            Second.Options = new List<string> { "Один корж - 200", "Два коржа - 400", "Три коржа - 600", "Четыре коржа - 800" };

                            break;
                        case 5:
                            Second.Options = new List<string> { "Шоколад - 150", "Крем - 200", "Безе - 350", "Драже - 200", "Ягоды - 350" };
                            break;
                        case 6:
                            Second.Options = new List<string> { "Шоколадный - 100", "Ягодный - 150", "Кремовый - 100" };

                            break;
                        case 7:
                            trigger = false;
                            break;


                    }

                    if (pos != 7)
                    {

                        Second.DrawMenu(x, y, ref Zakaz, Summa);
                        menu.MaxArrow = Second.Options.Count;
                        pos1 = menu.ShowArrow(); //Pos1 - номер строчки возвращаемого второстепенного меню

                        Zakaz[pos - 1] = Second.Options[pos1 - 1];

                        //Console.Write(Second.Options[pos1 - 1] + " ");
                        Summa = 0;

                        for (int i = 0; i < Zakaz.Length; i++)
                        {
                            int value;
                            //string txt = Second.Options[pos1].Substring(1);
                            string txt = Zakaz[i];
                            int.TryParse(string.Join("", txt.Where(c => char.IsDigit(c))), out value); //Value вписывает из строки цифры                    
                            Summa += value;

                        }
                        Main.DrawMenu(x, y, ref Zakaz, Summa);
                        menu.MaxArrow = Main.Options.Count;
                        pos = menu.ShowArrow();

                    }
                    else
                    {
                        trigger = false;
                        Number += 1;
                    }
                }
                string path = "C:\\Users\\Sasha\\Desktop\\Order.txt";

                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                string tempstring = $"\nВаш заказ номер {Number}:\n";
                for (int i = 0; i < Zakaz.Length; i++)
                {

                    tempstring += Zakaz[i] + " ";

                }
                File.AppendAllText(path, tempstring);
                File.AppendAllText(path, $"\nСумма заказа: {Summa}\n\n");

                int choise;

                Console.WriteLine("Будете еще заказывать?");
                Console.WriteLine(" 1 - да. \n2 - нет ");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                   
                    case 2:
                        trigger2 = false;
                        break;
                }
            }
            //string Order = File.ReadAllText("\"C:\\Users\\Sasha\\Desktop\\Order.txt\"");

        }






        //for (int i = 0; i < MainMenu.Count; i++)
        //{
        //    Console.SetCursorPosition(3, i);
        //    Console.WriteLine(MainMenu[i]);
        //}



    }

}




