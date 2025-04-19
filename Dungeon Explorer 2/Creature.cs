using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    abstract class Creature : IOutable
    {
        private string _name;
        private int _damage;
        private int _health;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    OutputText("Name has been set to Creature due to lack of answer");
                    _name = "Creature";
                }

                else
                {
                    _name = value;
                }
            }
        }
        public int Health
        {
            get { return _health; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    OutputText("Health has been set to 100 due to lack of answer");
                    _health = 100;
                }
                else if (value < 0)
                {
                    OutputText("Health has been set to 100 due to answer being less than 0");
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


        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public virtual void OutputText(string Message)
        {
            for (int x = 0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                Thread.Sleep(30);
            }
            Console.Write("\n");
        }
    }
}
