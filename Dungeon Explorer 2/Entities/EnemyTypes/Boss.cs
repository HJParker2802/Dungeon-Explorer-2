using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2.Entities
{
    class Boss : Monster
    {
        public Boss(string name) : base(name)
        {
            Name = name;
            Health = 1000;//Default value
            Damage = 45;//Default value
        }
    }
}
