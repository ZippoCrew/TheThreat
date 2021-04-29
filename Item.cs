using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreat
{
    class Item
    {
        private Player player;
        public string itemName;
        public Item(string itemName, Player player)
        {
            this.itemName = itemName;
            this.player = player;
        }

        public List<string> PickUp(string input)
        {
            if (input == "nehmen " + itemName)
            {
                if (player.Inventar.Contains(itemName))
                {
                    Console.WriteLine("Du hast diese Item bereits dabei.");
                }
                else
                {
                    Console.WriteLine("'" + itemName + "' ist jetzt in deinem Inventar");
                    player.Inventar.Add(itemName);
                }
            }
            return player.Inventar;
        }

        public bool Use(string input, string itemName, string useText, bool useBool)
        {
            if (input == "benutzen " + itemName)
            {
                if (player.Inventar.Contains(itemName))
                {
                    Console.WriteLine(useText);
                    useBool = false;
                }
                else
                {
                    Console.WriteLine("Das funktioniert so nicht.");
                }
            }
            return useBool;
        }
    }
}
