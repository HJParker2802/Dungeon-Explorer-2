using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// This is the Gamemap class, it inherits from IOutable
    /// IOutable interface is used to ensure that all outputs can be controlled through their own class
    /// </summary>
    class GameMap : IOutable
    {
        /// <summary>
        /// This is where all the Rooms are declared
        /// </summary>
        public Room CurrentRoom;
        //public Room Rooms[1];
        //public Room Rooms[2];
        //public Room Rooms[3];
        //public Room Rooms[4];
        //public Room Rooms[5];
        //public Room Rooms[6];
        //public Room Rooms[7];
        //public Room Rooms[8];
        public Room[] Rooms = new Room[9];


        protected Items CurrentWeapon;
        protected Items RustyDagger;
        protected Items String;
        protected Items LongSword;
        protected Items EnchantedLongSword;
        protected Items Torch;
        protected Items HealthPotion;
        protected Items PlaceHolder = new Items("Placeholder", 0, "A placeholder for the riddle and end room so the count isn't too low for it to work");



        /// <summary>
        /// This functions declare all the rooms with their set descriptions
        /// </summary>
        public void MakeRooms()
        {
            //Rooms[1] = new Room("You are in a small, dimly lit room with a rusted chest in the corner and a door leading to a corridor");
            //Rooms[2] = new Room("You are in a dimly lit corriodor with a torch on the wall");
            //Rooms[3] = new Room("You have entered a large room with a spider that wants to eat you");
            //Rooms[4] = new Room("You are in a room with a huge rat that thinks you look particularly tasty");
            //Rooms[5] = new Room("You are in a room with an annoying little mouse. You see a very small shine in the corner, maybe worth investigating?");
            //Rooms[6] = new Room("You are in a room with a huge ogre that thinks you stole its dinner, in the corner, there is a huge spider that wants to put you into its own cocoon!");
            //Rooms[7] = new Room("You are in a room with a bed, BUT WAIT, something feels off....");//TRAP ROOM     
            //Rooms[8] = new Room("You are in a room with a bed, it is time to rest and accept victory!");


            Rooms[1] = new Room("You are in a small, dimly lit room with a rusted chest in the corner and a door leading to a corridor");
            Rooms[2] = new Room("You are in a dimly lit corriodor with a torch on the wall");
            Rooms[3] = new Room("You have entered a large room with a spider that wants to eat you");
            Rooms[4] = new Room("You are in a room with a huge rat that thinks you look particularly tasty");
            Rooms[5] = new Room("You are in a room with an annoying little mouse. You see a very small shine in the corner, maybe worth investigating?");
            Rooms[6] = new Room("You are in a room with a huge ogre that thinks you stole its dinner, in the corner, there is a huge spider that wants to put you into its own cocoon!");
            Rooms[7] = new Room("You are in a room with a bed, BUT WAIT, something feels off....");//TRAP ROOM     
            Rooms[8] = new Room("You are in a room with a bed, it is time to rest and accept victory!");


            Rooms[1].Collectables = new List<Items>{ };
            Rooms[2].Collectables = new List<Items>{ };
            Rooms[3].Collectables = new List<Items>{ };
            Rooms[4].Collectables = new List<Items>{ };
            Rooms[5].Collectables = new List<Items>{ };
            Rooms[6].Collectables = new List<Items>{ };
            Rooms[7].Collectables = new List<Items>{ };
            Rooms[8].Collectables = new List<Items>{ };
            CurrentRoom = Rooms[1];
            OutputText(CurrentRoom.GetDescription());

            CreateItems();
            DeclareItems();   
        }
        void DeclareItems()
        {
            int RandomNum;


            //Randomly generated loot chance for Rooms[1]
            RandomNum = RandomNumber.RNG(1, 11);
            if (RandomNum % 10 == 0)
            {
                Rooms[1].Collectables = new List<Items>() { String, RustyDagger, HealthPotion };
            }
            else
            {
                Rooms[1].Collectables = new List<Items>() { String, RustyDagger };
            }

            //Randomly generated loot chance for Rooms[2]
            RandomNum = RandomNumber.RNG(1, 11);
            if (RandomNum % 5 == 0)
            {
                Rooms[2].ChangeDescription("You are in a dimly lit corriodor with a torch on the wall and something shiny on the floor");
                Rooms[2].Collectables = new List<Items>() { Torch, LongSword };
            }
            else
            {
                Rooms[2].Collectables = new List<Items>() { Torch };
            }


            //Randomly generated loot chance for Rooms[3]
            RandomNum = RandomNumber.RNG(1, 11);
            if (RandomNum % 10 == 0)
            {
                Rooms[3].ChangeDescription("You have entered a large room with a spider that wants to eat you, there also seems to be a mysterious bottle on the floor");
                Rooms[3].Collectables = new List<Items>() { HealthPotion };
            }
            else
            {
                Rooms[3].Collectables = new List<Items>() { };
            }


                //Randomly generated loot chance for Rooms[4]
                RandomNum = RandomNumber.RNG(1, 11);
            if (RandomNum % 10 == 0)
            {
                Rooms[4].ChangeDescription("You are in a room with a huge rat that thinks you look particularly tasty, there also seems to be a mysterious bottle on the floor");
                Rooms[4].Collectables = new List<Items>() { HealthPotion };
            }
            else
            {
                Rooms[4].Collectables = new List<Items>() { };
            }



            //Randomly generated loot chance for Rooms[5]
            RandomNum = RandomNumber.RNG(1, 11);
            if (RandomNum % 10 == 0)
            {
                Rooms[5].Collectables = new List<Items>() { EnchantedLongSword, HealthPotion, HealthPotion, HealthPotion};
            }
            else
            {
                Rooms[5].Collectables = new List<Items>() { EnchantedLongSword, HealthPotion };
            }



            //Randomly generated loot chance for Rooms[6]
            RandomNum = RandomNumber.RNG(1, 11);
            if (RandomNum % 10 == 0)
            {
                Rooms[6].ChangeDescription("You are in a room with a huge ogre that thinks you stole its dinner, in the corner, there is a huge spider that wants to put you into its own cocoon! You also see a mysterious bottle on the floor...");
                Rooms[6].Collectables = new List<Items>() { HealthPotion };
            }
            else
            {
                Rooms[6].Collectables = new List<Items>() { };
            }
            Rooms[7].Collectables = new List<Items>() {PlaceHolder};
            Rooms[8].Collectables = new List<Items>() {PlaceHolder};
        }

        public void CreateItems()
        {
            RustyDagger = new Weapons("Rusty Dagger", 25, "A rusty dagger, barely better than using a fist, barely....");
            String = new Items("Piece of String", 0, "A piece of string, it is completely useless");
            EnchantedLongSword = new Weapons("Enchanted Long Sword", 500, "A mystical blade, rumour has it, it's able to cut through almost anything, almost....");
            Torch = new Weapons("A torch", 0, "Just a torch from the wall");
            HealthPotion = new Potions("Health Potion", -25, "A shiny half full bottle, containing a red liquid, you can almost feel the healing properties, you feel a desire to drink it....");
            LongSword = new Weapons("Long Sword", 75, "A freshly smithed long sword, far better than using a simple dagger, you feel it willing you to conquer the dungeon....");

        }

        /// <summary>
        /// This returns the description for the current room 
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="Room.GetDescription()"/>
        public string GetDescription()
        {
            string CurrentDescription = CurrentRoom.GetDescription();
            return CurrentDescription;
        }

        /// <summary>
        /// This finds out what room you are in and allows the user to move forward a room
        /// </summary>
        public void NextRoom()
        {
            //string Description;
            //if (CurrentRoom == Rooms[1]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[2]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[2]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[3]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[3]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[4]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[4]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[5]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[5]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[6]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[6]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[7]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[7]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[8]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[8]) { OutputText("Cannot go further, Player is in the final room"); }
            bool RoomChangeDone=false;
            while(!RoomChangeDone)
            {
                if (RoomChangeDone) break;
                for (int ActiveRoom = 0; ActiveRoom < Rooms.Length; ActiveRoom++)
                {
                    if (RoomChangeDone) break;
                    if (CurrentRoom == Rooms[ActiveRoom])
                    {
                        if (CurrentRoom == Rooms[8])
                        {
                            OutputText("Cannot go further, Player is in the final room");
                            RoomChangeDone = true;
                            if (RoomChangeDone) break;
                        }
                        else
                        {
                            CurrentRoom = Rooms[ActiveRoom + 1];
                            Statistics.RoomsTravelled++;
                            OutputText(CurrentRoom.GetDescription());
                            RoomChangeDone = true;
                            if (RoomChangeDone) break;
                        }
                        if (RoomChangeDone) break;
                    }
                }
            }
        }

        /// <summary>
        /// This finds out what room you are in and allows the user to move backwards a room
        /// </summary>
        public void PreviousRoom()
        {
            //string Description;
            //if (CurrentRoom == Rooms[1]) { OutputText("Cannot go backwards, player is in the first room"); }
            //else if (CurrentRoom == Rooms[2]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[1]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[3]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[2]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[4]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[3]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[5]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[4]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[6]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[5]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[7]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[6]; OutputText(Description = CurrentRoom.GetDescription()); }
            //else if (CurrentRoom == Rooms[8]) { Statistics.RoomsTravelled++; CurrentRoom = Rooms[7]; OutputText(Description = CurrentRoom.GetDescription()); }

            for (int ActiveRoom = 0; ActiveRoom < Rooms.Length; ActiveRoom++)
            {
                if (CurrentRoom == Rooms[ActiveRoom])
                {
                    if (CurrentRoom == Rooms[1])
                    {
                        OutputText("Cannot go backwards, Player is in the first room");
                    }
                    else
                    {
                        CurrentRoom = Rooms[ActiveRoom - 1];
                        Statistics.RoomsTravelled++;
                        OutputText(CurrentRoom.GetDescription());
                    }
                }
            }


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
                Thread.Sleep(1);
            }
            Console.Write("\n\n");
        }
    }
}
