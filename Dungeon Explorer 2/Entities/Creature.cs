using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// This is the creatures classs, it inherits from IOutable and IDamageable 
    /// IOutable interface is used to ensure that all Creatures can output in their own controlled way
    /// IDamageable interface is used to ensure that all creatures can have controlled damage functions
    /// </summary>
    abstract class Creature : IOutable, IDamageable
    {
        /// <summary>
        /// This is where the Creatures name is privately stored
        /// </summary>
        private string _name;

        /// <summary>
        /// This is where the Creatures damage is privately stored
        /// </summary>
        private int _damage;

        /// <summary>
        /// This is where the Creatures health is privately stored
        /// </summary>
        private int _health;

        /// <summary>
        /// This is where the getters and setters for the name are, ensuring only valid names can be input
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (Name==null)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        OutputText("Invalid name has been set");
                        OutputText("Please try again! \nWhat is the player name? ");
                        Name = Console.ReadLine();
                    }

                    else
                    {
                        _name = value;
                    }
                }
            }
        }

        /// <summary>
        /// This is where the getters and setters for the health are, ensuring only valid names can be input
        /// </summary>
        public int Health
        {
            get { return _health; }
            set
            {
                if (value < 0)
                {
                    OutputText("Health given was invalid, setting to default 100");
                    _health = 100;
                }
                else
                {
                    _health = value;
                }
            }
        }

        /// <summary>
        /// This is where the getters and setters for the damage are, ensuring only valid names can be input
        /// </summary>
        public int Damage
        {
            get { return _damage; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    _damage = 15;//Damage has been set to 15 due to lack of answer

                }
                else if (value < 0)
                {
                    _damage = 15;//Damage has been set to 15 due to lack of answer
                }
                else
                {
                    _damage = value;
                }
            }
        }
                       
        /// <summary>
        /// This is the constructor for Creature with only the name parameter
        /// </summary>
        /// <param name="name"> declares the name to the getters and setters</param>
        public Creature(string name)
        {
            Name = name;
            Health = 100;//Default value
            Damage = -1; //Default value to be overriden by setters 
        }

        /// <summary>
        /// This is the constructor for Creature with both the name and health parameter
        /// </summary>
        /// <param name="name"> declares the name to the getters and setters</param>
        /// <param name="health"> declares the health to the getters and setters</param>
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
            Damage = -1; //Default value to be overriden by setters 
        }

        /// <summary>
        /// Constructtor for Creature with name, health and damage parameters 
        /// </summary>
        /// <param name="name"> declares the name to the getters and setters</param>
        /// <param name="health"> declares the health to the getters and setters</param>
        /// <param name="damage"> declares the damagee to the getters and setters</param>
        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// This is the abstract class for Equip, this will be used by the Player class
        /// </summary>
        /// <seealso cref="Player.Equip()"/>
        public abstract void Equip();//Not needed for creature
                                     //This is use of Dynamic polymorphism, as it will get overridden.


        /// <summary>
        /// Uses the function from interface IOutable
        /// Outputs text given to it
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>The Output Message, character by character with a sleep 0f 30</returns>
        /// <seealso cref="IOutable.OutputText(string)"/>
        public void OutputText(string Message)
        {
            for (int x = 0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                Thread.Sleep(10);
            }
            Console.Write("\n");
        }

        /// <summary>
        /// This is the damageable function,
        /// It allows player health to be impacte by the damageamount,
        /// This is used the by the Attack function
        /// </summary>
        /// <param name="DamageAmount"></param>
        /// <seealso cref="Attack(IDamageable)"/> 
        public virtual void Damageable(int DamageAmount)
        {
            if (Health == 0)
            {
                OutputText($"{Name} has already been destroyed!");
            }

            else if ((Health - DamageAmount) < 0)
            {
                Health = 0;
                OutputText($"{Name} has been destroyed!");
            }
            else
            {
                Health -= DamageAmount;

                if (Health == 0)
                {
                    OutputText($"{Name} has been destroyed!");
                }
                else
                {
                    OutputText($"{Name} took {DamageAmount} damage, health is now at {Health}");
                }
            }
        }

        /// <summary>
        /// This is the Attack function, It checks if the player is dead before attacking,
        /// and if they aren't, calls the Damageable function to take damage
        /// </summary>
        /// <param name="AttackedCreature"></param>
        /// <seealso cref="Damageable(int)"/>
        public virtual void Attack(IDamageable AttackedCreature)
        {
            if (Health == 0)
            {
                OutputText($"{Name} has already been destroyed!");
            }
            else
            {
                OutputText($"{Name} attacks for {Damage} damage!");
                AttackedCreature.Damageable(Damage);
            }
            
        }
    }
}
