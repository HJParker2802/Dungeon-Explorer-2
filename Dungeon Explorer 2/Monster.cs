using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Monster : Creature
    {
        public Monster(string name, int health, int damage) : base(name, health, damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        
    }
}
