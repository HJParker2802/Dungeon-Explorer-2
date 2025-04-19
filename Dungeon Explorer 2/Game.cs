using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Game : IOutable, IDamageable
    {
        private Player Player1;
        private Monster Monster1;
        public Weapons Dagger = new Weapons("Rusty Dagger 25", 25, "A rusty dagger, barely better than using a fist, barely....");
        public Weapons Dagger2 = new Weapons("Rusty Dagger 50", 50, "A rusty dagger, barely better than using a fist, barely....");
        public Weapons Dagger3= new Weapons("Rusty Dagger 75", 75, "A rusty dagger, barely better than using a fist, barely....");
        public Weapons Dagger5 = new Weapons("Rusty Dagger 100", 100, "A rusty dagger, barely better than using a fist, barely....");
        public Potions Healthpotion = new Potions("Health Potion", -25, "A shiny half full bottle, containing a red liquid, you can almost feel it making you feel better, you feel a desire to drink it....");
        
        public Game()
        {
            try
            {
                OutputText("The game is starting, you will be asked for some quick details before the game starts");

                // Initialize the game with one room and one player
                OutputText("Getting user information");
                OutputText("What is your name?");
                string Temp_Name = Console.ReadLine();
                OutputText("How much health would you like to start on? Typical health is 100.");
                string strStartHealth = Console.ReadLine();
                int StartHealth;

                bool ConvertChecker = int.TryParse(strStartHealth, out StartHealth);
                if (!ConvertChecker)
                {
                    StartHealth = -1;
                }
                if (StartHealth == 0)//Makes sure that starthealth is not 0, this is to ensure that if health becomes 0 through damage, it is not reset.
                {
                    StartHealth = -1;
                }

                Player1 = new Player(Temp_Name, StartHealth, -1); //Damage set as -1 so that it goes to default value
                Monster1 = new Monster("Spider", 50, -1);
                OutputText("");
            }
            catch(Exception e)
            {
                OutputText(e.Message);
            }
        }
        public void Start()
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
                    Player1.PickUpItem(Dagger);
                    Player1.PickUpItem(Dagger2);
                    Player1.PickUpItem(Dagger3);
                    Player1.PickUpItem(Dagger5);
                    Player1.PickUpItem(Healthpotion);
                    Player1.PickUpItem(Healthpotion);
                    OutputText(Player1.InventoryContents());


                    Player1.FilterInventory(Player1);
                    OutputText(Player1.InventoryContents());


                    //List<Items> Potions = Player1.InventoryPotions();
                    //OutputText(Player1.DisplayInventory(Potions));

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
            OutputText($"Entity details are below:");
            DisplayName(Creature);
            DisplayHealth(Creature);
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

        public virtual void OutputText(string Message)
        {
            for(int x=0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                //Thread.Sleep(30);
            }
            Console.Write("\n");
        }
        public virtual void Damage(Creature Attacker, Creature Attacked)
        {
            if (Attacked.Health == 0)
            {
                OutputText($"{Attacked.Name} has been destroyed!");
            }
            else
            {
                if ((Attacked.Health - Attacker.Damage) < 0)
                {
                    Attacked.Health = 0;
                    OutputText($"{Attacked.Name} has been destroyed!");
                }
                else
                {
                    Attacked.Health = Attacked.Health - Attacker.Damage;
                    OutputText($"{Attacked.Name} took {Attacker.Damage} damage, health is now at {Attacked.Health}");
                }
            }
        }

        public virtual void Heal(Creature Healable, int Amount)
        {
            Healable.Health = Healable.Health + Amount;
        }

    }
}
