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
    /// <summary>
    /// This is the Player class, it inherits from Creature and ICollectable
    /// </summary>
    class Player : Creature, ICollectable
    {
        private List<Items> Inventory = new List<Items> { };
        private Items CurrentItem;

        //Method overloading = use of static polymorphism
        
        /// <summary>
        /// Constructor for Player class
        /// </summary>
        /// <param name="name">pushes name to base</param>
        /// <param name="health">pushes health to base</param>
        public Player(string name, int health) : base(name, health)
        {
            Damage = 15;
        }


        /// <summary>
        /// Constructor for Player class
        /// </summary>
        /// <param name="name"> pushes name to main</param>
        /// <param name="health"> pushes health to main</param>
        /// <param name="damage"> pushes damage to main</param>
        public Player(string name, int health, int damage) : base(name, health, damage) { }


        /// <summary>
        /// Allows player to equip items, strongest in inventory 
        /// or choose items they want to use themselves
        /// </summary>
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

        /// <summary>
        /// ALlows Player to collect Items 
        /// </summary>
        /// <param name="Item"></param>
        public void Collect(Items Item)
        {
            Inventory.Add(Item);
            FilterInventory();//Filters inventory so items are always in order of what is most beneficial to attack with
            Statistics.CollectedItems++;
        }

        /// <summary>
        /// Removes set Items from the players inventory, used specifically for healthpotion to ensure player can't spam it and have unlimited health
        /// </summary>
        /// <param name="Item"></param>
        public void Remove(Items Item)
        {
            Inventory.Remove(Item);
            FilterInventory();//Filters inventory so items are always in order of what is most beneficial to attack with
        }

        /// <summary>
        /// Outputs the inventory content in the form of a string
        /// </summary>
        /// <returns></returns>
        public string InventoryContents()
        {
            if (Inventory.Count == 0)
            {
                return "There are no items in inventory";
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

        /// <summary>
        /// Filters the players inventory to ensure the strongest item is always at the start.
        /// </summary>
        public void FilterInventory()
        {//Use of Ternary Chain
            Inventory = Inventory
                .OrderByDescending(item =>
                item is Weapons weapons ? weapons.HealthImpact :
                item is Potions potions ? potions.HealthImpact :
                0)
                .ToList();
        }

        /// <summary>
        /// Shows the Item Details so the player knows what all of their items do. 
        /// </summary>
        /// <seealso cref="Equip()"/>
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

        /// <summary>
        /// This is the Attack function, It checks if the player is dead before attacking,
        /// and if they aren't, calls the Damageable function to take damage
        /// </summary>
        /// <param name="AttackedCreature"></param>
        /// <seealso cref="Damageable(int)"/>
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
                    OutputText($"{Name} strategically uses the blade and slices the target with {Damage} damage!");
                }
                AttackedCreature.Damageable(Damage);
            }
            
        }


    }
}
