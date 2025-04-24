using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Monster : Creature
    {

        public Monster(string name) : base(name)
        {
            Name = name;
            Health = 100;//Default value
            Damage = 15;//Default value
        }

        public Monster(string name, int health) : base(name, health)
        {
            Name = name;
            Health = health;
            Damage = 15;
        }
        public Monster(string name, int health, int damage) : base(name, health, damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public override void Equip() { OutputText("This does not do anything as Monsters do not need to pickup items"); }

        public override void Attack(IDamageable AttackedCreature)
        {
            if (Health==0)
            {
                OutputText($"{Name} has already been destroyed!");
            }
            else
            {
                OutputText($"{Name} throws itself at the target and lands {Damage} damage!");
                AttackedCreature.Damageable(Damage);
            }
            
        }

    }
}
