using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Program:IOutable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to test or play?");
            if (Console.ReadLine().ToUpper().Contains("T"))
            {
                Testing Test = new Testing();
                Test.Run();
            }
            else
            {
                Game game = new Game();
                game.Run();
            }
            Exit();
        }
        static void Exit()
        {
            Console.WriteLine("");
            Console.WriteLine("Program has ended");
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();

        }
        public virtual void OutputText(string Message)
        {
            for (int x = 0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                Thread.Sleep(10);
            }
            Console.Write("\n");
        }
    }
}
