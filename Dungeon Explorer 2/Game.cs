using Dungeon_Explorer_2.Entities;
using Dungeon_Explorer_2.Entities.EnemyTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Game : IOutable
    {
        protected Player Player1;
        protected Monster Monster1;


        protected Weapons CurrentWeapon;
        protected Weapons RustyDagger = new Weapons("Rusty Dagger", 25, "A rusty dagger, barely better than using a fist, barely....");
        protected Weapons Dagger = new Weapons("Dagger", 50, "A freshly smithed dagger, far better than using a fist, yet still worse than any real sword");
        protected Weapons LongSword = new Weapons("Long Sword", 75, "A freshly smithed long sword, far better than using a simple dagger, you feel it willing you to conquer the dungeon....");
        protected Weapons EnchantedLongSword = new Weapons("Enchanted Long Sword", 500, "A mystical blade, rumour has it, it's able to cut through almost anything, almost....");
        protected Items Torch = new Items("A torch", 0, "Just a torch from the wall");
        protected Potions HealthPotion = new Potions("Health Potion", -25, "A shiny half full bottle, containing a red liquid, you can almost feel the healing properties, you feel a desire to drink it....");
        
        public Game()
        {
            try
            {
                OutputText("The game is starting, you will be asked for some quick details before the game starts");

                OutputText("Getting user information");
                OutputText("What is your name?");
                string Temp_Name = Console.ReadLine();
                OutputText("How much health would you like to start on? Typical health is 100.");
                string strStartHealth = Console.ReadLine();
                int StartHealth;

                bool ConvertChecker = int.TryParse(strStartHealth, out StartHealth);
                if (!ConvertChecker)
                {
                    OutputText("Input was incorrect format,");
                    StartHealth = -1;
                }
                if (StartHealth == 0)//Makes sure that starthealth is not 0, this is to ensure that if health becomes 0 through damage, it is not reset.
                {
                    StartHealth = -1;
                }

                Player1 = new Player(Temp_Name, StartHealth, -1); //Damage set as -1 so that it goes to default value
                //Monster1 = new Spider("Spider", 50, -1);
                Monster1 = new Boss("Giant");

                OutputText("");
            }
            catch(Exception e)
            {
                OutputText(e.Message);
            }
        }
        public void Run()
        {
            try
            {
                bool playing = true;
                while (playing)
                {
                    if (Player1.Health <= 0)
                    {
                        playing = false;
                        break;
                    }
                    if (Monster1.Health <= 0)
                    {
                        playing = false;
                        break;
                    }
                    OutputText("Do you want to stop playing?");
                    string Answer = Console.ReadLine();
                    if (Answer.ToUpper().Contains("Y"))
                    {
                        playing = false;
                        break;
                    }
                    OutputText("Game continuing");//Just here so I can see the game hasn't ended by input error 
                    Player1.Collect(Dagger);
                    //Player1.Collect(RustyDagger);
                    //Player1.Collect(EnchantedLongSword);
                    //Player1.Collect(LongSword);
                    //Player1.Collect(HealthPotion);

                    //OutputText(Player1.InventoryContents());

                    //Player1.ItemDetails();

                    DisplayDetails(Player1);

                    //Player1.Attack(Monster1);
                    //Monster1.Attack(Player1);


                    Player1.Equip();

                    //Player1.Attack(Monster1);

                    //DisplayDetails(Player1);

                    playing = false; 
                }
            }
            catch(Exception e)
            {
                OutputText(e.Message);
            }
            
        }
        void DisplayDetails(Creature Creature)
        {
            OutputText($"\nEntity details are below:");
            DisplayName(Creature);
            DisplayHealth(Creature);
            DisplayDamage(Creature);
            OutputText("");
        }
        void DisplayName(Creature Creature)
        {
            OutputText($"Name:{Creature.Name}");
        }
        void DisplayHealth(Creature Creature)
        {
            if (Creature.Health == 0)
            {
                OutputText($"{Creature.Name} has been destroyed");
            }
            else
            {
                OutputText($"Health:{Creature.Health}");
            }
        }
        void DisplayDamage(Creature Creature)
        {
            OutputText($"Damage:{Creature.Damage}");
        }

        public virtual void OutputText(string Message)
        {
            for(int x=0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                Thread.Sleep(10);
            }
            Console.Write("\n");
        }
    }
}
