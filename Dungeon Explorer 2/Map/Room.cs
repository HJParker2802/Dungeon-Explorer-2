using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
        public void ChangeDescription(string NewDescription)
        {
            description = NewDescription;
        }
    }
}
