using Dungeon_Explorer_2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Player : Creature, ICollectable
    {
        private List<Items> Inventory = new List<Items> { };
        private List<Items> WeaponInventory;
        private List<Items> PotionInventory;

        //Method overloading = use of static polymorphism
        public Player(string name, int health) : base(name, health)
        {
            Damage = 15;
        }
        public Player(string name, int health, int damage) : base(name, health, damage){}

        public override void Equip()
        {
            OutputText("What item do you want to use?");
            OutputText(InventoryContents());
            OutputText("Enter item Name");
            string UseItem = Console.ReadLine();
            OutputText($"Item chosen: {UseItem}");

            bool present = Inventory.Any(Inventory => Inventory.ItemName.Equals(UseItem,StringComparison.OrdinalIgnoreCase));//LINQ

            if(present)
            {
                OutputText("It worked");
                for (int x=0; x<Inventory.Count; x++)
                {
                    if (Inventory[x].ItemName.Equals(UseItem, StringComparison.OrdinalIgnoreCase))
                    {
                        if (Inventory[x].HealthImpact >= 0)
                        {
                            Damage = Inventory[x].HealthImpact;
                        }
                        else if (Inventory[x].HealthImpact <0)
                        {//If it's less than 0, it is a health potion, so it is intended to impact the player health not the enemy health
                            Health -= Inventory[x].HealthImpact;
                        }
                    }
                }
            } 
            else
            {
                OutputText("Could not find item, would you like to try again? (Respond Yes or No)");
                string UserChoice = Console.ReadLine();
                if(UserChoice.ToUpper().Contains("Y"))
                {
                    OutputText("Trying again!");
                    Equip();
                }
                else { OutputText("No items were equipped"); }
            }   
        }

        public void Collect(Items item)
        {
            Inventory.Add(item);
            FilterInventory();//Filters inventory so items are always in order of what is most beneficial to attack with
        }
        public string InventoryContents()
        {
            string Contents = "";
            for (int i = 0; i < Inventory.Count; i++)
            {
                Contents = $"{Contents} {Inventory[i].ItemName},";
            }

            Contents = Contents.Remove(Contents.Length - 1);
            return Contents;
        }
        public List<Items> InventoryWeapons()
        {
            WeaponInventory =
                Inventory.OfType<Weapons>()
                .Cast<Items>().ToList();

            return WeaponInventory;
        }
        public List<Items> InventoryPotions()
        {
            PotionInventory =
                Inventory.OfType<Potions>()
                .Cast<Items>().ToList();
            return PotionInventory;
        }

        public string DisplayInventory(List<Items> SetInventory)
        {
            string Contents = "";
            for (int i = 0; i < SetInventory.Count; i++)
            {
                Contents = $"{Contents} {SetInventory[i].ItemName},";
            }

            Contents = Contents.Remove(Contents.Length - 1);
            return Contents;
        }

        public void FilterInventory()
        {//Use of Ternary Chain
            Inventory = Inventory
                .OrderByDescending(item =>
                item is Weapons weapons ? weapons.HealthImpact :
                item is Potions potions ? potions.HealthImpact :
                0)
                .ToList();
        }

        public void ItemDetails()
        {
            OutputText("What item do you want to Look at?");
            OutputText(InventoryContents());
            OutputText("Enter item Name");
            string UseItem = Console.ReadLine();
            OutputText($"Item chosen for description: {UseItem}");

            bool present = Inventory.Any(Inventory => Inventory.ItemName.Equals(UseItem, StringComparison.OrdinalIgnoreCase));//LINQ
            if (present)
            {
                for (int x = 0; x < Inventory.Count; x++)
                {
                    if (Inventory[x].ItemName.Equals(UseItem, StringComparison.OrdinalIgnoreCase))
                    {
                        OutputText($"Name:{Inventory[x].ItemName}");
                        OutputText($"Description:{Inventory[x].GetItemDescription()}");
                        OutputText($"Health Impact:{Inventory[x].HealthImpact}");
                    }
                }
                OutputText("Do you want to look at another item? (Respond Yes or No)");
                string UsersChoice = Console.ReadLine();
                if (UsersChoice.ToUpper().Contains("Y"))
                {
                    ItemDetails();
                }
            }
            else
            {
                OutputText("Could not find item, would you like to try again? (Respond Yes or No)");
                string UserChoice = Console.ReadLine();
                if (UserChoice.ToUpper().Contains("Y"))
                {
                    OutputText("Trying again!");
                    ItemDetails();
                }
                else { OutputText("No items were equipped"); }
            }
        }

    }
}
