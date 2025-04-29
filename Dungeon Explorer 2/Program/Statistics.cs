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
    /// <summary>
    /// Statistics class, inherits from IOutable
    /// IOutable interface is used to ensure that all outputs can be controlled through their own class
    /// </summary>
    public class Statistics: IOutable
    {
        /// <summary>
        /// Stores the amount of Kills made
        /// </summary>
        public static int Kills { get; set; }
        
        /// <summary>
        /// Stores the amount of Items Collected
        /// </summary>
        public static int CollectedItems { get; set; }
        
        /// <summary>
        /// Stores the amount of times the player travelled between rooms 
        /// </summary>
        public static int RoomsTravelled { get; set; }


        /// <summary>
        /// Displays the statistics for kills, collected items and rooms travelled.
        /// </summary>
        public void DisplayStats()
        {
            OutputText($"Displaying Statistics" +
                $"Number of Kills: {Kills}\n" +
                $"Number of Items Collected: {CollectedItems}\n" +
                $"Amount of time player moved between rooms: {RoomsTravelled}");
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
