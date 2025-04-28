using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// Class used to create rooms with names and descriptions
    /// </summary>
    class Room
    {
        /// <summary>
        /// private variable for the description to be stored
        /// </summary>
        private string description;

        /// <summary>
        /// Collectables for all rooms
        /// </summary>
        public List<Items> Collectables;
        
        /// <summary>
        /// Constructor for the Room class
        /// </summary>
        /// <param name="description"> declares the description in the constructor</param>
        public Room(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// Function to be able to return the description to an outputable form
        /// </summary>
        /// <returns>the description</returns>
        public string GetDescription()
        {
            return description;
        }

        /// <summary>
        /// Function to be able to change the room description,
        /// This is only used when the player takes the light from a room and alters
        /// the rooms appearance, meaning the description would need changing
        /// </summary>
        /// <param name="NewDescription"></param>
        public void ChangeDescription(string NewDescription)
        {
            description = NewDescription;
        }
    }
}
