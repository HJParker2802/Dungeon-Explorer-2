using Dungeon_Explorer_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// Potions class, inherits from Items and IUsable
    /// </summary>
    class Potions : Items, IUsable
    {
        public Potions(string itemName, int healthImpact, string description) : base(itemName, healthImpact, description){}

        /// <summary>
        /// Use function for the Potions to heal the player
        /// </summary>
        /// <param name="Player1"></param>
        public void Use(Player Player1)
        {
            int healed = -HealthImpact;
            Player1.Health += healed;
            OutputText($"{ItemName} used. {Player1.Name} healed for {healed} Health. Current health is now:{Player1.Health}");
            Player1.Remove(this);
        }
    }
}
