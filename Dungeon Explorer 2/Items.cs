using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Items
    {
        private string _itemName;
        private int _healthImpact;
        private string _description;

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

        public Items(string itemName, int healthImpact, string description)
        {
            ItemName = itemName;
            HealthImpact = healthImpact;
            Description = description;
        }

        public virtual string GetItemDescription()
        {
            return Description;
        }
    }
}
