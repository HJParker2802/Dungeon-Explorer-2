using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2.Entities
{
    class Boss : Monster
    {

        /// <summary>
        /// Constructor for the Boss class
        /// </summary>
        /// <param name="name"> pushes the name to the base class</param>
        public Boss(string name) : base(name)
        {
            Name = name;
            Health = 1000;//Default value
            Damage = 45;//Default value
        }

        /// <summary>
        /// Attack function specific to the Boss class
        /// </summary>
        /// <param name="AttackedCreature"></param>
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
