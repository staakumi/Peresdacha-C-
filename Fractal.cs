using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortiki
{
    internal class Fractal
    {
        public List<string> Options;

        public Fractal()
        {
            Options = new List<string>(); // Конструктор по умолчанию
        }
        public Fractal(List<string> TempList) // Конструктор 
        {
            Options = TempList;
        }
        public void DrawMenu(int x, int y, ref string[] Zakaz, int Summa )
        {
           Console.Clear();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.Write(Options[i]);
                y++;
                Console.SetCursorPosition(x, y);
            }

            Console.SetCursorPosition(0, 20);
            
            Console.WriteLine("Вы выбрали:");
            for (int i = 0; i < Zakaz.Length; i++)
            {
                Console.Write(Zakaz[i] + " ");
            }

            Console.Write("\nОбщая сумма заказа: " + Summa);
           

            
        }

       
    }
}
