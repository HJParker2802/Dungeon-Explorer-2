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
        public override void Attack(IDamageable AttackedCreature)
        {
            if(Health==0)
            {
                OutputText($"{Name} has already been destroyed!");
            }
            else
            {
                OutputText($"{Name} uses their extreme strength to land a powerful blow of {Damage} damage!");
                AttackedCreature.Damageable(Damage);
            }
            
        }
    }
}
