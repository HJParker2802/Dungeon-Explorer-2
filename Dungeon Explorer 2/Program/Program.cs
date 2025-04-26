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
        /// <summary>
        /// The main function of Program
        /// Runs Test object and Game object
        /// </summary>
        /// <param name="args"></param>
        /// <returns>string[] args</returns>
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

        /// <summary>
        /// Allows the program to gracefully exit while informing the user
        /// Outputs text given to it
        /// </summary>
        static void Exit()
        {
            Console.WriteLine("");
            Console.WriteLine("Program has ended");
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }


        /// <summary>
        /// Uses the function from interface IOutable
        /// Outputs text given to it
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>The Output Message, character by character with a sleep 0f 30</returns>
        /// <seealso cref="IOutable.OutputText(string)"/>
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
