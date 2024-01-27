using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_skoropechatanie
{
    internal class Mytimer
    {
        public int StartTime;

        public Mytimer()
        {
            StartTime = 60;
        }

        public void SecondsTimer()
        {
            int sound = 200;
            while (StartTime > 0)
            {
            Thread.Sleep(1000);
            sound += 10;
                Console.Beep(sound, 100);
            StartTime--;
            Console.SetCursorPosition(15, 20);
                Console.Write("У вас осталось: ");
                Console.Write(StartTime);
            Console.Write("  ");

            }
            


        }

    }
}
