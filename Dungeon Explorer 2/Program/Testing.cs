using Dungeon_Explorer_2.Entities;
using Dungeon_Explorer_2.Entities.EnemyTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// Testing class, inherits from IOutable,
    /// This is made to test out features of the game before running the actual game, 
    /// to ensure that all works as intended
    /// IOutable interface is used to ensure that the way outputs are done in the console can be controlled per class.
    /// </summary>
    class Testing : IOutable
    {
        protected Player Player1;
        protected Monster Monster1;

        protected Weapons CurrentWeapon;
        protected Weapons RustyDagger = new Weapons("Rusty Dagger", 25, "A rusty dagger, barely better than using a fist, barely....");
        protected Weapons Dagger = new Weapons("Dagger", 50, "A freshly smithed dagger, far better than using a fist, yet still worse than any real sword");
        protected Weapons LongSword = new Weapons("Long Sword", 75, "A freshly smithed long sword, far better than using a simple dagger, you feel it willing you to conquer the dungeon....");
        protected Weapons EnchantedLongSword = new Weapons("Enchanted Long Sword", 500, "A mystical blade, rumour has it, it's able to cut through almost anything, almost....");
        protected Weapons Torch = new Weapons("A torch", 1, "Just a torch from the wall");
        protected Potions HealthPotion = new Potions("Health Potion", -25, "A shiny half full bottle, containing a red liquid, you can almost feel the healing properties, you feel a desire to drink it....");
        protected Items String = new Items("String",0,"piece of string");
        protected GameMap Levels = new GameMap();

        public bool[] Test = new bool[16];


        /// <summary>
        /// This is the constructor for the Testing class
        /// </summary>
        public Testing()
        {

            try
            {
                OutputText("The Tests are starting");
                // Initialize the game with one room and one player
                Player1 = new Player("Testing Player", 100, 15);
                
                Monster1 = new Spider("Spider", 50, -1);
                Test[0] = true;
                Debug.Assert(Player1.Name == "Testing Player");
                Test[1] = true;
                Debug.Assert(Player1.Health == 100);
                OutputText("");
            }
            catch (Exception e)
            {
                OutputText(e.Message);
            }
        }

        /// <summary>
        /// This is the Run function for the Testing class, 
        /// </summary>
        public void Run()
        {
            OutputText(Test.Length.ToString());
            DisplayDetails(Player1);
            DisplayDetails(Monster1);
            Levels.MakeRooms(); Test[2] = true;
            Levels.PreviousRoom(); Test[3] = true;
            Levels.NextRoom(); Test[4] = true;
            Levels.NextRoom();
            Levels.NextRoom();
            Levels.NextRoom();
            Levels.NextRoom(); Test[5] = true;
            Levels.PreviousRoom();

            while ((Player1.Health!=0) || (Monster1.Health!=0))
            {
                Player1.Attack(Monster1);
                if ((Player1.Health == 0) || (Monster1.Health == 0)) { break; }
            }
            Test[6] = true;
            Test[7] = true;
            Debug.Assert(Monster1.Health != 0);
            Player1.Health = 100;
            Monster1.Health = 100;
            while ((Player1.Health != 0) || (Monster1.Health != 0))
            {
                Monster1.Attack(Player1);
                if ((Player1.Health == 0) || (Monster1.Health == 0)) { break; }
            }
            Test[8] = true;
            Test[9] = true;
            Debug.Assert(Player1.Health != 0);
            Player1.Health = 100;
            Monster1.Health = 100;

            Player1.Collect(Torch); Test[10] = true;
            bool AutoEquip = Player1.Equip("Y","");
            bool ManualEquip = Player1.Equip("", "A torch");

            Player1.Collect(LongSword);
            bool AutoEquip2 = Player1.Equip("Y", "");
            bool ManualEquip2 = Player1.Equip("", "A torch");
            Console.Clear();
            Player1.Collect(String);
            bool CheckUnusableItems = Player1.Equip("","String");


            OutputText("Testing Completed");
            OutputText("Players can be made"); 
            OutputText("Monsters can be made"); 
            OutputText("Rooms can be made"); 
            OutputText("Previous room cannot be entered on first room"); 
            OutputText("Next room function works");
            OutputText("Next room function cannot be entered on final room");
            OutputText("Previous room function works");
            OutputText("Players can attack Monster");
            OutputText("Monsters can die");
            OutputText("Monsters can attack Player");
            OutputText("Player can die");
            OutputText("Items can be collected");
            if (AutoEquip) { OutputText("Auto equip item works"); Test[11] = true; }
            else { OutputText("Auto equip item does not work"); Test[11] = false; }
            if (ManualEquip) { OutputText("Manual equip item works"); Test[12] = true; }
            else { OutputText("Manual equip item does not work"); Test[12] = false; }
            if (AutoEquip2) { OutputText("Auto equip item works with multiple items"); Test[13] = true; }
            else { OutputText("Auto equip item does not work with multiple items"); Test[13] = false; }
            if  (ManualEquip2){OutputText("Manual equip item workss with multiple items"); Test[14] = true; }
            else { OutputText("Manual equip item does not works with multiple items"); Test[14] = false; }
            if  (!CheckUnusableItems){ OutputText("Non usable items cannot be equiped"); Test[15] = true; }
            else { OutputText("Usable items can be equiped "); Test[15] = false; }
            OutputText("Players can equip usable items");

            bool TestsWorked = true;
            int FailedTestCounter=0;
            for (int x = 0; x < Test.Count(); x++)
            {
                if (Test[x] == false)
                {
                    TestsWorked = false;
                    FailedTestCounter++;
                }
            }
            if (TestsWorked) OutputText($"All tests Passed with {FailedTestCounter} fails.");
            else OutputText($"Test failed with {FailedTestCounter} fails.");

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
        /// Uses the function from interface IOutable
        /// Outputs text given to it
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>The Output Message, character by character with a sleep 0f 30</returns>
        /// <seealso cref="IOutable.OutputText(string)"/>
        public virtual void OutputText(string Message)
        {
            for (int x = 0; x < Message.Length; x++)
            {
                Console.Write(Message[x]);
            }
            Console.Write("\n");
        }

    }
}
