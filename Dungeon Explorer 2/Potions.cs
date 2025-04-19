using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Potions : Items
    {
        public Potions(string itemName, int healthImpact, string description) : base(itemName, healthImpact, description)
        {
            ItemName = itemName;
            HealthImpact = healthImpact;
            Description = description;
        }
    }
}
