using Dungeon_Explorer_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Weapons : Items, IUsable
    {
        public Weapons(string itemName, int healthImpact, string description) : base(itemName, healthImpact, description){}


        public void Use(Player Player1)
        {
            Player1.Damage = this.HealthImpact;
            OutputText($"{ItemName} equipped. Player damage is now {Player1.Damage}.");
        }

    }
}
