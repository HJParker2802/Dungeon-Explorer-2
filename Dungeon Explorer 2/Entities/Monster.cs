using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// This is the Monster class, it inherits from Creature and ICollectable
    /// Monster inherits from Creature class as the Creature class is used as a blueprint for the player class
    /// Monster uses ICollectable interface to ensure that the interface can be used exactly as necessary regardless of which class it is used in
    /// </summary>
    class Monster : Creature
    {
        /// <summary>
        /// This is the constructor for Creature with only the name parameter
        /// </summary>
        /// <param name="name">declares the name back to base to ensure it is valid</param>
        public Monster(string name) : base(name)
        {
            Name = name;
        }

        /// <summary>
        /// This is the constructor for Creature with only the name and health parameter
        /// </summary>
        /// <param name="name">declares the name back to base to ensure it is valid</param>
        /// <param name="health">declares the health back to base to ensure it is valid</param>
        public Monster(string name, int health) : base(name, health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// This is the constructor for Creature with the name, health and damage parameter
        /// </summary>
        /// <param name="name">declares the name back to base to ensure it is valid</param>
        /// <param name="health">declares the health back to base to ensure it is valid</param>
        /// <param name="damage">declares the damage back to base to ensure it is valid</param>
        public Monster(string name, int health, int damage) : base(name, health, damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// Equip function does not get used by Monsters, if used, will output saying it does nothing.
        /// </summary>
        public override void Equip() { OutputText("This does not do anything as Monsters do not need to pickup items"); }


        /// <summary>
        /// This is the Attack function, It checks if the player is dead before attacking,
        /// and if they aren't, calls the Damageable function to take damage
        /// </summary>
        /// <param name="AttackedCreature"></param>
        /// <seealso cref="Creature.Damageable(int)"/>
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
