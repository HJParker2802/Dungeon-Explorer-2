using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
            //Console.WriteLine("Game start has finished running");
            Exit();
        }
        static void Exit()
        {
            Console.WriteLine("");
            Console.WriteLine("Program has ended");
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();

        }
    }
}
