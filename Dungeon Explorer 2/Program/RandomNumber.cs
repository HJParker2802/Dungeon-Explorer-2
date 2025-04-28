using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// Random Number generator class,
    /// this is used for random events such as potions spawning randomly in rooms
    /// Or enemies wandering in to rooms
    /// Or for if an enemy decides to hit the player or not
    /// </summary>
    public static class RandomNumber
    {
        /// <summary>
        /// RANDOM variable is used to create the random numbers for the user
        /// </summary>
        static Random RANDOM = new Random();

        /// <summary>
        /// Random Number generator function,
        /// this is used to generate a random number throughout the game
        /// </summary>
        /// <param name="MinValue">This is the minimum number generated</param>
        /// <param name="MaxValue">This is the maximum number generated</param>
        /// <returns></returns>
        public static int RNG(int MinValue, int MaxValue)
        {
            return RANDOM.Next(MinValue, MaxValue);
        }

    }
}
