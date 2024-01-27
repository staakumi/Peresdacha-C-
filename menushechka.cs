using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortiki
{
    internal class Menu
    {
        public int MinArrow;
        public int MaxArrow;

        public Menu(int min, int max)
        {
            MinArrow = min;
            MaxArrow = max;
        }

        public int ShowArrow()
        {
            int pos = 1;
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

               key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != MinArrow)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != MaxArrow)
                {
                    pos++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

            } while (key.Key != ConsoleKey.Escape);

            return pos; //Возвращается позиция от единицы до Count
        }
    }
}
