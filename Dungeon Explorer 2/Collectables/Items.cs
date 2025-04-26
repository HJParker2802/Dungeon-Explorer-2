using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// Items class, inherits from IOutable
    /// </summary>
    class Items: IOutable
    {
        /// <summary>
        /// Where item names are privately stored
        /// </summary>
        private string _itemName;

        /// <summary>
        /// Where Health impacts are privately stored
        /// </summary>
        private int _healthImpact;

        /// <summary>
        /// Where descriptions are privately stored
        /// </summary>
        private string _description;

        /// <summary>
        /// This is where the getters and setters for the ItemName are, ensuring only valid names can be input
        /// </summary>
        public string ItemName
        {
            get { return _itemName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {//if no name given, name it Item
                    _itemName = "Item";
                }
                else
                {            
                    _itemName = value;
                }
            }
        }

        /// <summary>
        /// This is where the getters and setters for the health impact are, ensuring only valid names can be input
        /// </summary>
        public int HealthImpact
        {
            get { return _healthImpact; }
            set 
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {//if no effect given, make it 0
                    _healthImpact = 0;
                }
                else
                {
                    _healthImpact = value;
                }
            }
        }

        /// <summary>
        /// This is where the getters and setters for the Description are, ensuring only valid names can be input
        /// </summary>
        public string Description
        {
            get { return _description; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {//if empty description, gives basic description of an item
                    _description = "The Item can be used or consumed by the player to aid them in their fights";
                }
                else
                {
                    _description = value;
                }
            }
        }


        /// <summary>
        /// Constructor for Items
        /// </summary>
        /// <param name="itemName"> pushes to Itemname for getters and setters</param>
        /// <param name="healthImpact">pushes to HealthImpact for getters and setters</param>
        /// <param name="description">pushes to Description for getters and setters</param>
        public Items(string itemName, int healthImpact, string description)
        {
            ItemName = itemName;
            HealthImpact = healthImpact;
            Description = description;
        }


        /// <summary>
        /// Getst the item description
        /// </summary>
        /// <returns>returns description </returns>
        public virtual string GetItemDescription()
        {
            return Description;
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
                Thread.Sleep(10);
            }
            Console.Write("\n");
        }
    }
}
