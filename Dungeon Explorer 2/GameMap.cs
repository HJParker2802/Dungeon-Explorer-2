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
        Room CurrentRoom;
        Room Room1;
        Room Room2;
        Room Room3;
        Room Room4;
        Room Room5;

        public void MakeRooms()
        {
            Room Room1 = new Room("You are in a small, dimly lit room with a rusted chest in the corner and a door leading to a corridor");
            Room Room2 = new Room("You are in a corridor that has dim lighting");
            Room Room3 = new Room("You have entered a large room with a huge spider that wants to eat you");
            Room Room4 = new Room("You are in a room with a huge ogre that thinks you stole its dinner");
            Room Room5 = new Room("You are in a room with a bed, it is time to rest and accept victory!");
            CurrentRoom = Room1;
        }
        public string GetDescription()
        {
            string CurrentDescription = CurrentRoom.GetDescription();
            return CurrentDescription;
        }
        public void NextRoom()
        {
            if (CurrentRoom == Room1) { CurrentRoom = Room2; }
            else if (CurrentRoom == Room2) { CurrentRoom = Room3; }
            else if (CurrentRoom == Room3) { CurrentRoom = Room4; }
            else if (CurrentRoom == Room4) { CurrentRoom = Room5; }
            else if (CurrentRoom == Room5) { OutputText("Cannot change room, Player is in the final room"); }
        }

        public void PreviousRoom()
        {
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
                Thread.Sleep(30);
            }
            Console.Write("\n");
        }
    }
}
