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
        private Items CurrentItem;

        //Method overloading = use of static polymorphism
        public Player(string name, int health) : base(name, health)
        {
            Damage = 15;
        }
        public Player(string name, int health, int damage) : base(name, health, damage) { }

        public override void Equip()
        {
            if (Inventory.Count == 0)
            {
                OutputText("There are no items in inventory");
            }
            else
            {
                OutputText("Do you want to equip the best weapon you have?");
                if (Console.ReadLine().ToUpper().Contains("Y"))
                {
                    Items StrongestItem = Inventory.OrderByDescending(i => i.HealthImpact).FirstOrDefault();

                    if (StrongestItem != null && StrongestItem is IUsable UsableItem)
                    {
                        OutputText("Strongest weapon found");
                        UsableItem.Use(this);
                    }
                    else
                    {
                        OutputText("There was no findable item");
                    }
                }
                else
                {
                    OutputText("What item do you want to use?");
                    OutputText(InventoryContents());
                    OutputText("Enter item Name");
                    string UseItem = Console.ReadLine();
                    OutputText($"Item chosen: {UseItem}");

                    Items Item = Inventory.FirstOrDefault(i => i.ItemName.Equals(UseItem, StringComparison.OrdinalIgnoreCase));

                    if (Item != null && Item is IUsable UsableItem)
                    {
                        UsableItem.Use(this);
                        CurrentItem = Item;
                        OutputText("Do you want to equip anything else? (Yes or No)");
                        if (Console.ReadLine().ToUpper().Contains("Y"))
                        {
                            Equip();
                        }
                    }
                    else
                    {
                        OutputText("Could not find item or item cannot be used. Try again? (Yes or No)");
                        if (Console.ReadLine().ToUpper().Contains("Y"))
                        {
                            Equip();
                        }
                    }
                }
            }
        }

        public void Collect(Items Item)
        {
            Inventory.Add(Item);
            FilterInventory();//Filters inventory so items are always in order of what is most beneficial to attack with
        }
        public void Remove(Items Item)
        {
            Inventory.Remove(Item);
            FilterInventory();//Filters inventory so items are always in order of what is most beneficial to attack with
        }
        public string InventoryContents()
        {
            if (Inventory.Count == 0)
            {
                OutputText("There are no items in inventory");
                return "";
            }
            else
            {
                string Contents = "";
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Contents = $"{Contents} {Inventory[i].ItemName},";
                }

                Contents = Contents.Remove(Contents.Length - 1);
                return Contents;
            }
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
            if (Inventory.Count == 0)
            {
                OutputText("There are no items in inventory");
            }
            else
            {
                OutputText("\nItem details \n");
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
                    if (Console.ReadLine().ToUpper().Contains("Y"))
                    {
                        ItemDetails();
                    }
                }
                else
                {
                    OutputText("Could not find item, would you like to try again? (Respond Yes or No)");
                    if (Console.ReadLine().ToUpper().Contains("Y"))
                    {
                        OutputText("Trying again!!");
                        ItemDetails();
                    }
                    else { OutputText("No items were detailed"); }
                }
            }
        }

        public override void Attack(IDamageable AttackedCreature)
        {
            if (Health ==0)
            {
                OutputText($"{Name} has already been destroyed!");
            }
            else
            {
                if (CurrentItem == null)
                {//Punch
                    OutputText($"{Name} lunges themselves towards the target and lands a hit of {Damage} damage!");
                }
                else if (CurrentItem != null)
                {//Use weapon
                    OutputText($"{Name} attacks for {Damage} damage!");
                    OutputText($"{Name} strategically uses the blade and slices the target with {Damage} damage!");
                }
                AttackedCreature.Damageable(Damage);
            }
            
        }


    }
}
