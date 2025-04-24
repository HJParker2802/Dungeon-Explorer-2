using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class GameMap : IOutable
    {
        public Room CurrentRoom;
        public Room Room1;
        public Room Room2;
        public Room Room3;
        public Room Room4;
        public Room Room5;
        public Room Room6;
        public Room Room7;
        public Room Room8;

        public void MakeRooms()
        {
            string Description;
            Room1 = new Room("You are in a small, dimly lit room with a rusted chest in the corner and a door leading to a corridor");
            Room2 = new Room("You are in a corridor that has dim lighting");
            Room3 = new Room("You have entered a large room with a huge spider that wants to eat you");
            Room4 = new Room("You are in a room with a huge rat that thinks you look particularly tasty");
            Room5 = new Room("You are in a room with an annoying little mouse. You see a very small shine in the corner, maybe worth investigating?");
            Room6 = new Room("You are in a room with a huge ogre that thinks you stole its dinner, in the corner, there is a spider that wants to put you into its own cocoon!");
            Room7 = new Room("You are in a room with a bed, BUT WAIT, something feels off....");//TRAP ROOM
            Room8 = new Room("You are in a room with a bed, it is time to rest and accept victory!");
            CurrentRoom = Room1;
            OutputText(Description = CurrentRoom.GetDescription());
        }
        public string GetDescription()
        {
            string CurrentDescription = CurrentRoom.GetDescription();
            return CurrentDescription;
        }
        public void NextRoom()
        {
            string Description;
            if (CurrentRoom == Room1) { CurrentRoom = Room2; Description = CurrentRoom.GetDescription(); OutputText(Description); }
            else if (CurrentRoom == Room2) { CurrentRoom = Room3; Description = CurrentRoom.GetDescription(); OutputText(Description); }
            else if (CurrentRoom == Room3) { CurrentRoom = Room4; Description = CurrentRoom.GetDescription(); OutputText(Description); }
            else if (CurrentRoom == Room4) { CurrentRoom = Room5; Description = CurrentRoom.GetDescription(); OutputText(Description); }
            else if (CurrentRoom == Room5) { OutputText("Cannot change room, Player is in the final room"); }
        }

        public void PreviousRoom()
        {
            string Description;
            if (CurrentRoom == Room1) { OutputText("Cannot change room, player is in the first room"); }
            else if (CurrentRoom == Room2) { CurrentRoom = Room1; }
            else if (CurrentRoom == Room3) { CurrentRoom = Room2; }
            else if (CurrentRoom == Room4) { CurrentRoom = Room3; }
            else if (CurrentRoom == Room5) { CurrentRoom = Room4; }
        }

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
