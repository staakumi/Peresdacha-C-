using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Threading;

namespace Test_skoropechatanie
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Text mytext = new Text();
            Mytimer timer = new Mytimer();
            Console.CursorVisible = false;
            string path = "1.txt";
            string test = File.ReadAllText(path);
            char charkey;

            Thread thread = new Thread(_ =>
            {
                while (true)
                {
                    timer.SecondsTimer();
                }
            });
            thread.Start();


            while (true)
            {
                ConsoleKeyInfo keychar = Console.ReadKey(true);
                charkey = Convert.ToChar(keychar.KeyChar);
                if (charkey == mytext.textchar[mytext.position])
                {
                    mytext.position++;
                }

                mytext.PrintText();



            }


        }



    }
}
