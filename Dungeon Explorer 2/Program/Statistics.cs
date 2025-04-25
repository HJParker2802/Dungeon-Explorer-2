using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Dungeon_Explorer_2
{
    public class Statistics: IOutable
    {
        public static int Kills { get; set; }
        public static int CollectedItems { get; set; }
        public static int RoomsTravelled { get; set; }

        public void DisplayStats()
        {
            OutputText($"Displaying Statistics" +
                $"Number of Kills: {Kills}\n" +
                $"Number of Items Collected: {CollectedItems}\n" +
                $"Amount of time player moved between rooms: {RoomsTravelled}");
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
