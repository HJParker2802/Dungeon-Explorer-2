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

    /// <summary>
    /// Game class, used to run the game
    /// Uses IOutable interface to control how data is output onto the console
    /// </summary>
    class Game : IOutable
    {
        protected Player ThePlayer;

        protected Creature HugeSpider;
        protected Creature HugeRat;
        protected Creature LittleMouse;
        protected Creature HugeOgre;
        protected Creature RegSpider;



        protected GameMap LevelSystem;

        protected Statistics Stats = new Statistics();

        /// <summary>
        /// This is the constructor for the Game class
        /// </summary>
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
                
                OutputText("");

            }
            catch(Exception e)
            {
                OutputText(e.Message);
            }
        }

        /// <summary>
        /// This is the Run function for the Game class, 
        /// It runs and controls the actual game loop
        /// </summary>
        public void Run()
        {
            try
            {
                //Declaring variables
                bool playing = true;
                int OptionsAnswer;
                bool TrapSolved = false;
                LevelSystem.MakeRooms();
                //List<Items> Room1Collectables = new List<Items>() {String, RustyDagger };
                //List<Items> Room2Collectables = new List<Items>() {Torch };
                //List<Items> Room5Collectables = new List<Items>() {EnchantedLongSword, HealthPotion};




                while (playing)
                {
                    if (ThePlayer.Health <= 0)
                    {
                        OutputText($"{ThePlayer} has died.");
                        playing = false;
                        break;
                    }
                    if (!playing) { break; }                    
                    //Options Menu
                    OutputText("\nWhat would you like to do?");
                    OutputText("[1] End Game");
                    OutputText("[2] View Player Deatils");
                    OutputText("[3] View Room Description");
                    OutputText("[4] Interact With Inventory");
                    OutputText("[5] Investigate Room");
                    OutputText("[6] Fight Enemy");
                    OutputText("[7] Change Room");
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
                            OutputText("[2] Investigate Items in Inventory");
                            OutputText("[3] Look at Items in Inventory");
                            while (OptionsAnswer !=1 || OptionsAnswer !=2 || OptionsAnswer !=3)//Loop to make sure the user inputs a valid answer
                            {
                                OutputText("Please input a number to state what you want to do");
                                bool ConvertChecker = int.TryParse(Console.ReadLine(), out OptionsAnswer);
                                if (OptionsAnswer != 0) { break; }
                            }
                            if (OptionsAnswer == 1) { ThePlayer.Equip(); }
                            else if (OptionsAnswer == 2) { ThePlayer.ItemDetails(); }
                            else if (OptionsAnswer == 3) { OutputText(ThePlayer.InventoryContents()); }
                                break;
                        case 5:
                            for(int ActiveRoom=0; ActiveRoom < LevelSystem.Rooms.Length; ActiveRoom++)
                            {
                                if(LevelSystem.CurrentRoom == LevelSystem.Rooms[ActiveRoom])
                                {
                                    if (LevelSystem.Rooms[ActiveRoom].Collectables.Count == 0)
                                    {
                                        string active = LevelSystem.Rooms[ActiveRoom].GetDescription();
                                        string current = LevelSystem.CurrentRoom.GetDescription();

                                        OutputText("There are no collectables here");
                                    }
                                    else
                                    {
                                        //Controls what the output is depending on the players room
                                        switch (ActiveRoom)
                                        {
                                            case 1:
                                                OutputText("You approach the rusted chest in the corner\nYou open the chest and take the items it contained, adding them to your inventory");
                                                break;
                                            case 2:
                                                OutputText("You take the torch off the wall and place it into your inventory");
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count > 1) OutputText("You also take the potion from the wall and place it into your inventory");
                                                LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a very dark corriodor with no torch on the wall");
                                                break;
                                            case 3:
                                                OutputText("You pickup the bottle filled with red, and place it into your inventory");
                                                LevelSystem.Rooms[ActiveRoom].ChangeDescription("You have entered a large room with a spider that wants to eat you");
                                                break;
                                            case 4:
                                                OutputText("You pickup the mysterious bottle and place it into your inventory");
                                                LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge rat that thinks you look particularly tasty");
                                                break;
                                            case 5:
                                                OutputText("You approach the shine in the corner");
                                                OutputText("You find a chest made of glass");
                                                OutputText("You open the glass chest and see a shining longsword and a glowing health potion");
                                                if (LittleMouse.Health == 0) LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in an empty room, the 5th room, just empty.");
                                                else LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with an annoying little mouse.");
                                                break;
                                            case 6:
                                                OutputText("You pickup the mysterious bottle and place it into your inventory");
                                                if (HugeOgre.Health == 0 && HugeSpider.Health == 0)
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in an empty room, the 6th room, just empty.");
                                                else if (HugeOgre.Health == 0)
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge spider that wants to put you into its own cocoon!");
                                                else if (HugeSpider.Health == 0)
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge ogre that thinks you stole its dinner!");
                                                else
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in an empty room, the 6th room, just empty.");
                                                break;
                                            case 7:

                                                OutputText("The bed disappears and turns into a sheet of paper");
                                                OutputText("On the paper you see a riddle ");
                                                OutputText("I’m a number greater than ten, ");
                                                OutputText("A dozen eggs, again and again.");
                                                OutputText("Three times four, or six times two,");
                                                OutputText("A highly composite point of view.");
                                                OutputText("What number am I ? ");
                                                OutputText("Hint, the ogre should have told you when it died, as long as you defeated it....");
                                                string Answer = "";
                                                while (Answer != "12")
                                                {
                                                    if (Answer == "12") { break; }
                                                    OutputText("What number am I");
                                                    Answer = Console.ReadLine();
                                                }
                                                TrapSolved = true;
                                                OutputText("You have successfully completed the riddle, you may go to the next room.");
                                                break;
                                            case 8:
                                                OutputText("In front of you, you see a bed, it is finally time to rest");
                                                OutputText("Do you want to get into the bed?(Yes or No)");
                                                if (Console.ReadLine().ToUpper().Contains("Y"))
                                                {
                                                    OutputText("You get into the bed, you may finally rest!");
                                                    OutputText($"{ThePlayer.Name} has won!");
                                                    OutputText("Game ending");
                                                    playing = false;
                                                    break;
                                                }
                                                break;
                                        }
                                        for (int x = 0; x < LevelSystem.Rooms[ActiveRoom].Collectables.Count; x++)
                                        {
                                            ThePlayer.Collect(LevelSystem.Rooms[ActiveRoom].Collectables[x]);
                                        }
                                    }
                                }
                            }
                            break;
                        case 6:
                            for (int ActiveRoom = 0; ActiveRoom < LevelSystem.Rooms.Length; ActiveRoom++)
                            {
                                if (LevelSystem.CurrentRoom == LevelSystem.Rooms[ActiveRoom])
                                {
                                    switch(ActiveRoom)
                                    {
                                        case 1:
                                            OutputText("There are no monsters to fight!");
                                            break;
                                        case 2:
                                            OutputText("There are no monsters to fight!");
                                            break;
                                        case 3:
                                            if (RegSpider.Health != 0)
                                            {
                                                OutputText($"{RegSpider.Name} has found you!");
                                                while (RegSpider.Health != 0)
                                                {
                                                    if (RegSpider.Health == 0) { break; }
                                                    RegSpider.Attack(ThePlayer);
                                                    OutputText($"Do you want to attack {RegSpider.Name}?(Yes or No)");
                                                    if (Console.ReadLine().ToUpper().Contains("Y"))
                                                    {
                                                        ThePlayer.Attack(RegSpider);
                                                    }
                                                }
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count == 0) LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a large empty room, the 3rd room, just empty.");
                                                else LevelSystem.Rooms[ActiveRoom].ChangeDescription("You have entered a large room where there seems to be a mysterious bottle on the floor");
                                                Statistics.Kills++;
                                            }
                                            else
                                            {
                                                OutputText($"You have already killed the {RegSpider.Name}");
                                            }
                                            break;
                                        case 4:
                                            if (HugeRat.Health != 0)
                                            {
                                                OutputText($"{HugeRat.Name}has found you!");
                                                while (HugeRat.Health != 0)
                                                {
                                                    if (HugeRat.Health == 0) { break; }
                                                    HugeRat.Attack(ThePlayer);
                                                    if (ThePlayer.Health == 0) { playing = false; break; }
                                                    OutputText($"Do you want to attack {HugeRat.Name}?(Yes or No)");
                                                    if (Console.ReadLine().ToUpper().Contains("Y"))
                                                    {
                                                        ThePlayer.Attack(HugeRat);
                                                    }
                                                }
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count == 0) LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in an empty room, the 4th room, just empty.");
                                                else LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room where there seems to be a mysterious bottle on the floor");
                                                Statistics.Kills++;
                                            }
                                            else
                                            {
                                                OutputText($"You have already killed {HugeRat.Name}");
                                            }
                                            break;
                                        case 5:
                                            if (LittleMouse.Health != 0)
                                            {
                                                while (LittleMouse.Health != 0)
                                                {
                                                    if (LittleMouse.Health == 0) { break; }
                                                    ThePlayer.Attack(LittleMouse);
                                                }
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count == 0) LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in an empty room, the 5th room, just empty.");
                                                else LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room where there is a very small shine in the corner, may be worth investigating?");
                                                Statistics.Kills++;
                                            }
                                            else
                                            {
                                                OutputText($"{LittleMouse.Name} has already been defeated!");
                                            }
                                            break;
                                        case 6:
                                            OptionsAnswer = 0;
                                            while (OptionsAnswer != 1 || OptionsAnswer != 2)
                                            {
                                                OutputText("What do you want to do?");
                                                OutputText($"[1] Attack the {HugeOgre.Name}");
                                                OutputText($"[2] Attack the {HugeSpider.Name}");
                                                bool ConverChecker = int.TryParse(Console.ReadLine(), out OptionsAnswer);
                                                if (OptionsAnswer == 1 || OptionsAnswer == 2) { break; }
                                            }
                                            if (OptionsAnswer == 1)
                                            {
                                                if (HugeOgre.Health != 0)
                                                {
                                                    while (HugeOgre.Health != 0)
                                                    {
                                                        HugeOgre.Attack(ThePlayer);
                                                        if (ThePlayer.Health == 0) { playing = false; break; }
                                                        OutputText($"Do you want to attack {HugeOgre.Name}?(Yes or No)");
                                                        if (Console.ReadLine().ToUpper().Contains("Y"))
                                                        {
                                                            ThePlayer.Attack(HugeOgre);
                                                        }
                                                        if (HugeOgre.Health == 0) { OutputText("The answer is 12, remember that!"); break; }
                                                    }
                                                    Statistics.Kills++;
                                                }
                                                else
                                                {
                                                    OutputText($"{HugeOgre.Name} has already been defeated!");
                                                }
                                            }
                                            else if (OptionsAnswer == 2)
                                            {
                                                if (HugeSpider.Health != 0)
                                                {
                                                    while (HugeSpider.Health != 0)
                                                    {
                                                        if (HugeSpider.Health == 0) { break; }
                                                        HugeSpider.Attack(ThePlayer);
                                                        if (ThePlayer.Health == 0) { playing = false; break; }
                                                        OutputText($"Do you want to attack {HugeSpider.Name}?(Yes or No)");
                                                        if (Console.ReadLine().ToUpper().Contains("Y"))
                                                        {
                                                            ThePlayer.Attack(HugeSpider);
                                                        }
                                                    }
                                                    Statistics.Kills++;
                                                }
                                                else
                                                {
                                                    OutputText($"{HugeSpider.Name} has already been defeated!");
                                                }
                                            }


                                            if (HugeOgre.Health == 0 && HugeSpider.Health == 0)
                                            {
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count==0)
                                                {
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in an empty room, the 6th room, just empty.");
                                                }
                                                else
                                                {
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a mysterious bottle on the floor...");
                                                }
                                            }
                                            else if (HugeOgre.Health == 0)
                                            {
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count == 0)
                                                {
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge spider that wants to put you into its own cocoon!");
                                                }
                                                else
                                                {
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge spider that wants to put you into its own cocoon! You also see a mysterious bottle on the floor...");
                                                }
                                            }
                                            else if (HugeSpider.Health == 0)
                                            {
                                                if (LevelSystem.Rooms[ActiveRoom].Collectables.Count == 0)
                                                {
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge ogre that thinks you stole its dinner!");
                                                }
                                                else
                                                {
                                                    LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge ogre that thinks you stole its dinner! You also see a mysterious bottle on the floor...");
                                                }
                                            }
                                            else
                                            {
                                                LevelSystem.Rooms[ActiveRoom].ChangeDescription("You are in a room with a huge ogre that thinks you stole its dinner, in the corner, there is a huge spider that wants to put you into its own cocoon!");
                                            }
                                            break;
                                        case 7:
                                            OutputText("There are no monsters to fight!");
                                            break;
                                        case 8:
                                            OutputText("There are no monsters to fight!");
                                            break;
                                    }
                                }
                            }
                            break;
                        case 7:
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
                                if(LevelSystem.CurrentRoom==LevelSystem.Rooms[7] && !TrapSolved)
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

        /// <summary>
        /// Displays the details of the creature input
        /// </summary>
        /// <param name="Creature">The Creature we want the details of.</param>
        /// <returns>The details of the creature given</returns>
        void DisplayDetails(Creature Creature)
        {
            OutputText($"\nEntity details are below:");
            DisplayName(Creature);
            DisplayHealth(Creature);
            DisplayDamage(Creature);
            OutputText("");
        }
        /// <summary>
        /// Displays the Name of the creature input
        /// </summary>
        /// <param name="Creature">The Creature we want the name of.,</param>
        /// <param name="Creature.Name">The Creatures name.,</param>
        /// <returns>The Name of the creature given</returns>
        void DisplayName(Creature Creature)
        {
            OutputText($"Name:{Creature.Name}");
        }

        /// <summary>
        /// Displays the Health of the creature input
        /// </summary>
        /// <param name="Creature">The Creature we want the details of.,</param>
        /// <param name="Creature.Name">The Creatures damage.,</param>
        /// <param name="Creature.Health">The Creatures damage.,</param>
        /// <returns>The Health of the creature given</returns>
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
        /// <summary>
        /// Displays the Damage of the creature input
        /// </summary>
        /// <param name="Creature">The Creature we want the details of.,</param>
        /// <param name="Creature.Damage">The Creatures damage.,</param>
        /// <returns>The Damage of the creature given</returns>
        void DisplayDamage(Creature Creature)
        {
            OutputText($"Damage:{Creature.Damage}");
        }

        /// <summary>
        /// Creates the Enemies with names, health and attack damage
        /// </summary>
        public void CreateEnemies()
        {
            RegSpider = new Spider("Spider", 25, 5);
            HugeRat = new Monster("Huge smelly Rat", 20, 15);
            LittleMouse = new Monster("Tiny mouse", 5, 0);
            HugeOgre = new Boss("Huge stinky ogre");
            HugeSpider = new Spider("Huge hairy spider");
        }

        /// <summary>
        /// Creates the Items with names, descriptions and attack damage
        /// </summary>


        /// <summary>
        /// Uses the function from interface IOutable
        /// Outputs text given to it
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>The Output Message, character by character with a sleep 0f 30</returns>
        /// <seealso cref="IOutable.OutputText(string)"/>
        public virtual void OutputText(string Message)
        {
            for(int x=0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
                //Thread.Sleep(30);
            }
            Console.Write("\n");
        }
    }
}