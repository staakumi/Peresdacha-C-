using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test_skoropechatanie
{
    internal class Text
    {
        public char[] textchar;
        public int textLength;
        public int position = 0;


        public Text()
        {
            string test = File.ReadAllText("1.txt");
            textLength = test.Length;
            textchar = new char[textLength];

            for (int i = 0; i < textLength; i++)
            {
                textchar[i] = test[i];

            }

        }
        public void PrintText()
        {
            ConsoleColor defaultcolor = Console.ForegroundColor;

            Console.SetCursorPosition(0, 3);
            for (int i = 0; i < textLength; i++)
            {
                if (i < position)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(textchar[i]);
                    
                }
                else
                {
                    Console.ForegroundColor = defaultcolor;
                    Console.Write(textchar[i]);
                }
            }
            Console.SetCursorPosition(0, 0);

        }


    }
}
