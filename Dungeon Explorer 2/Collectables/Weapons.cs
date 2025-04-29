using Dungeon_Explorer_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// Weapons class, inherits from Items, IUsable
    /// Items is inherited from as it is a blueprint for how Weapons are structured as weapons are items
    /// IUsable is inherited from to ensure that all weapons will be usable by the player
    /// </summary>
    class Weapons : Items, IUsable
    {
        public Weapons(string itemName, int healthImpact, string description) : base(itemName, healthImpact, description){}

        /// <summary>
        /// Use function which Player class pulls from
        /// </summary>
        /// <param name="Player1"></param>
        /// <seealso cref="Player.Attack(IDamageable)"/>
        public void Use(Player Player1)
        {
            Player1.Damage = this.HealthImpact;
            OutputText($"{ItemName} equipped. Player damage is now {Player1.Damage}.");
        }

    }
}
