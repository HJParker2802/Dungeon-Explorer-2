using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    class Player : Creature
    {
        private List<Items> Inventory = new List<Items> { };
        private List<Items> WeaponInventory;
        private List<Items> PotionInventory;


        public Player(string name, int health, int damage) : base(name, health, damage) 
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void PickUpItem(Items item)
        {
            Inventory.Add(item);
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

        public void FilterInventory(Player Player)
        {//Use of Ternary Chain
            Player.Inventory = Player.Inventory
                .OrderByDescending(item =>
                item is Weapons weapons ? weapons.HealthImpact :
                item is Potions potions ? potions.HealthImpact :
                0)
                .ToList();
        }

    }
}
