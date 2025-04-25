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
            Room2 = new Room("You are in a dimly lit corriodor with a torch on the wall");
            Room3 = new Room("You have entered a large room with a spider that wants to eat you");
            Room4 = new Room("You are in a room with a huge rat that thinks you look particularly tasty");
            Room5 = new Room("You are in a room with an annoying little mouse. You see a very small shine in the corner, maybe worth investigating?");
            Room6 = new Room("You are in a room with a huge ogre that thinks you stole its dinner, in the corner, there is a huge spider that wants to put you into its own cocoon!");
            Room7 = new Room("You are in a room with a bed, BUT WAIT, something feels off....");//TRAP ROOM     Nicks idea of maths is being stolen!
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
            if (CurrentRoom == Room1) { Statistics.RoomsTravelled++; CurrentRoom = Room2; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room2) { Statistics.RoomsTravelled++; CurrentRoom = Room3; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room3) { Statistics.RoomsTravelled++; CurrentRoom = Room4; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room4) { Statistics.RoomsTravelled++; CurrentRoom = Room5; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room5) { Statistics.RoomsTravelled++; CurrentRoom = Room6; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room6) { Statistics.RoomsTravelled++; CurrentRoom = Room7; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room7) { Statistics.RoomsTravelled++; CurrentRoom = Room8; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room8) { OutputText("Cannot go further, Player is in the final room"); }
        }

        public void PreviousRoom()
        {
            string Description;
            if (CurrentRoom == Room1) { OutputText("Cannot go backwards, player is in the first room"); }
            else if (CurrentRoom == Room2) { Statistics.RoomsTravelled++; CurrentRoom = Room1; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room3) { Statistics.RoomsTravelled++; CurrentRoom = Room2; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room4) { Statistics.RoomsTravelled++; CurrentRoom = Room3; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room5) { Statistics.RoomsTravelled++; CurrentRoom = Room4; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room6) { Statistics.RoomsTravelled++; CurrentRoom = Room5; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room7) { Statistics.RoomsTravelled++; CurrentRoom = Room6; OutputText(Description = CurrentRoom.GetDescription()); }
            else if (CurrentRoom == Room8) { Statistics.RoomsTravelled++; CurrentRoom = Room7; OutputText(Description = CurrentRoom.GetDescription()); }

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
