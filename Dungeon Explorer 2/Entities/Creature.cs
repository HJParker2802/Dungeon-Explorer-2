using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    abstract class Creature : IOutable, IDamageable
    {
        private string _name;
        private int _damage;
        private int _health;

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
        public int Health
        {
            get { return _health; }
            set
            {
                if (value < 0)
                {
                    OutputText("Health given was less than 0, setting to default 100");
                    _health = 100;
                }
                else
                {
                    _health = value;
                }
            }
        }

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
                       
        public Creature(string name)
        {
            Name = name;
            Health = 100;//Default value
            Damage = -1; //Default value to be overriden by setters 
        }
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
            Damage = -1; //Default value to be overriden by setters 
        }
        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public abstract void Equip();//Not needed for creature
        //This is use of Dynamic polymorphism, as it will get overridden.
        public void OutputText(string Message)
        {
            for (int x = 0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                Thread.Sleep(10);
            }
            Console.Write("\n");
        }

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
