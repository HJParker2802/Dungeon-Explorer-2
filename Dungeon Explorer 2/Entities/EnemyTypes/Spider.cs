using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Dungeon_Explorer_2.Entities.EnemyTypes
{
    /// <summary>
    /// This is the spider class, it inherits from Monster
    /// Spider class inherits from Monster as it is a different, more specific type of enemy that has its own Attack function that is unique to it
    /// </summary>
    class Spider : Monster
    {

        /// <summary>
        /// Constructor for the Spider class
        /// </summary>
        /// <param name="name">gets pushed to base</param>
        public Spider(string name) : base(name)
        {
            Name = name;
            Health = 75;//Default value
            Damage = 15;//Default value
        }

        /// <summary>
        /// Constructor for the Spider class
        /// </summary>
        /// <param name="name">gets pushed to base</param>
        /// <param name="health">gets pushed to base</param>
        public Spider(string name, int health) : base(name, health)
        {
            Name = name;
            Health = health;
            Damage = 15;//Default value
        }

        /// <summary>
        /// Constructor for the Spider class
        /// </summary>
        /// <param name="name">gets pushed to base</param>
        /// <param name="health">gets pushed to base</param>
        /// <param name="damage">gets pushed to base</param>
        public Spider(string name, int health,int damage) : base(name, health, damage) { }

        /// <summary>
        /// Attack function specific to the spider class
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
                OutputText($"{Name} puts the target in a cocoon and bites the target for {Damage} damage!");
                AttackedCreature.Damageable(Damage);
            }

        }
    }
}
