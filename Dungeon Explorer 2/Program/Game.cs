using Dungeon_Explorer_2.Entities;
using Dungeon_Explorer_2.Entities.EnemyTypes;
using Dungeon_Explorer_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Game : IOutable
    {
        protected Player ThePlayer;

        protected Creature HugeSpider;
        protected Creature HugeRat;
        protected Creature LittleMouse;
        protected Creature HugeOgre;
        protected Creature RegSpider;

        protected Items CurrentWeapon;
        protected Items RustyDagger;
        protected Items String;
        protected Items LongSword;
        protected Items EnchantedLongSword;
        protected Items Torch;
        protected Items HealthPotion;

        protected GameMap LevelSystem;

        protected Statistics Stats = new Statistics();


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

                ThePlayer = new Player(Temp_Name, StartHealth, -1); //Damage set as -1 so that it goes to default value
                LevelSystem = new GameMap();
                CreateEnemies();
                CreateItems();
                
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
                //Declaring variables
                bool playing = true;
                int OptionsAnswer;
                bool TrapSolved = false;
                LevelSystem.MakeRooms();
                List<Items> Room1Collectables = new List<Items>() {String, RustyDagger };
                List<Items> Room2Collectables = new List<Items>() {Torch };

                while (playing)
                {
                    if (ThePlayer.Health <= 0)
                    {
                        OutputText($"{ThePlayer} has died.");
                        playing = false;
                        break;
                    }
                    //OutputText("Do you want to stop playing?");
                    //string Answer = Console.ReadLine();
                    //if (Answer.ToUpper().Contains("Y")){ playing = false; break; }
                    //OutputText("Game continuing");//Just here so I can see the game hasn't ended by input error 
                    
                    //Options Menu
                    OutputText("What would you like to do?");
                    OutputText("[1] End Game");
                    OutputText("[2] View Player Deatils");
                    OutputText("[3] View Room Description");
                    OutputText("[4] Interact With Inventory");
                    OutputText("[5] Interact With Room");
                    OutputText("[6] Change Room");
                    OptionsAnswer = 0;

                    while (OptionsAnswer == 0)//Loop to make sure the user inputs an answer
                    {
                        OutputText("Please input a number to state what you want to do");
                        bool ConvertChecker = int.TryParse(Console.ReadLine(), out OptionsAnswer);
                        if (OptionsAnswer != 0) { break; }
                    }
                    switch(OptionsAnswer)
                    {
                        case 1:
                            playing = false;
                            break;
                        case 2:
                            DisplayDetails(ThePlayer);
                            break;
                        case 3:
                            OutputText(LevelSystem.GetDescription());
                            //Crap goes here
                            break;
                        case 4:
                            OptionsAnswer = 0;
                            OutputText("What would you like to do?");
                            OutputText("[1] Equip Items in Inventory");
                            OutputText("[2] Look at Items in Inventory");
                            while (OptionsAnswer !=1 || OptionsAnswer !=2)//Loop to make sure the user inputs a valid answer
                            {
                                OutputText("Please input a number to state what you want to do");
                                bool ConvertChecker = int.TryParse(Console.ReadLine(), out OptionsAnswer);
                                if (OptionsAnswer != 0) { break; }
                            }
                            if (OptionsAnswer == 1) { ThePlayer.Equip(); }
                            else if (OptionsAnswer == 2) { ThePlayer.ItemDetails(); }
                            break;
                        case 5:
                            //Crap goes here
                            if (LevelSystem.CurrentRoom == LevelSystem.Room1)
                            {
                                if (Room1Collectables.Count == 0)
                                {
                                    OutputText("You go back over the the chest");
                                    OutputText("The chest is empty");
                                }
                                else
                                {
                                    OutputText("You approach the rusted chest in the corner\nYou open the chest and take the items it contained, adding them to your inventory");
                                    for (int x = 0; x < Room1Collectables.Count; x++)
                                    {
                                        ThePlayer.Collect(Room1Collectables[x]);
                                    }
                                    Room1Collectables.Clear();
                                    ThePlayer.ItemDetails();
                                }
                            }
                            else if (LevelSystem.CurrentRoom == LevelSystem.Room2)
                            {
                                if (Room2Collectables.Count == 0)
                                {
                                    OutputText("You have already placed the torch in your inventory");
                                }
                                else
                                {
                                    OutputText("You take the torch off the wall and place it into your inventory");
                                    for (int x = 0; x < Room2Collectables.Count; x++)
                                    {
                                        ThePlayer.Collect(Room2Collectables[x]);
                                    }
                                    Room2Collectables.Clear();
                                    ThePlayer.ItemDetails();
                                    LevelSystem.Room2.ChangeDescription("You are in a very dark corriodor with no torch on the wall");
                                    LevelSystem.CurrentRoom = LevelSystem.Room2;
                                    OutputText("You have taken the torch from the room, the new description will show.");
                                    OutputText(LevelSystem.GetDescription());
                                }
                            }
                            else if (LevelSystem.CurrentRoom == LevelSystem.Room3)
                            {
                                
                            }
                            break;

                        case 6:
                            OptionsAnswer = 0;
                            OutputText("What would you like to do?");
                            OutputText("[1] Go to Next Room");
                            OutputText("[2] Go to Previous Room");
                            while (OptionsAnswer != 1 || OptionsAnswer != 2)//Loop to make sure the user inputs a valid answer
                            {
                                OutputText("Please input a number to state what you want to do");
                                bool ConvertChecker = int.TryParse(Console.ReadLine(), out OptionsAnswer);
                                if (OptionsAnswer != 0) { break; }
                            }
                            if (OptionsAnswer == 1)
                            {
                                if(LevelSystem.CurrentRoom==LevelSystem.Room7 && !TrapSolved)
                                {
                                    OutputText($"{ThePlayer.Name} cannot pass until the trap has been solved!");
                                }
                                else
                                {
                                    LevelSystem.NextRoom();
                                    
                                }
                            }
                            else if (OptionsAnswer == 2) { LevelSystem.PreviousRoom(); }
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                OutputText(e.Message);
            }
            finally
            {
                OutputText("The game has ended \n");
                Stats.DisplayStats();
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
        public void CreateEnemies()
        {
            RegSpider = new Spider("Spider", 25, 5);
            HugeRat = new Monster("Huge smelly Rat", 20, 15);
            LittleMouse = new Monster("Tiny mouse", 5, 0);
            HugeOgre = new Boss("Huge stinky ogre");
            HugeSpider = new Spider("Huge hairy spider");
        }
        public void CreateItems()
        {
            RustyDagger = new Weapons("Rusty Dagger", 25, "A rusty dagger, barely better than using a fist, barely....");
            String = new Items("Piece of String", 0, "A piece of string, it is completely useless");
            LongSword = new Weapons("Long Sword", 75, "A freshly smithed long sword, far better than using a simple dagger, you feel it willing you to conquer the dungeon....");
            EnchantedLongSword = new Weapons("Enchanted Long Sword", 500, "A mystical blade, rumour has it, it's able to cut through almost anything, almost....");
            Torch = new Weapons("A torch", 0, "Just a torch from the wall");
            HealthPotion = new Potions("Health Potion", -25, "A shiny half full bottle, containing a red liquid, you can almost feel the healing properties, you feel a desire to drink it....");
        }
        public virtual void OutputText(string Message)
        {
            for(int x=0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                Thread.Sleep(30);
            }
            Console.Write("\n");
        }
    }
}
