using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Dungeon_Explorer_2.Entities.EnemyTypes
{
    class Spider : Monster
    {
        public Spider(string name) : base(name)
        {
            Name = name;
            Health = 75;//Default value
            Damage = 15;//Default value
        }
        public Spider(string name, int health) : base(name, health)
        {
            Name = name;
            Health = health;
            Damage = 15;//Default value
        }
        public Spider(string name, int health,int damage) : base(name, health, damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public override void Attack(IDamageable AttackedCreature)
        {
            if(Health==0)
            {
                OutputText($"{Name} has already been destroyed!");
            }
            else
            {
                OutputText($"{Name} puts the target in a cocoon and bites the target for {Damage} damage!");
                AttackedCreature.Damageable(Damage);
            }

        }
    }
}
