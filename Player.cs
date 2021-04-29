using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreat
{
    class Player
    {
        public List<string> Inventar = new List<string>();
        // Game wird übergeben
        private Game game;
        public Player(Game game)
        {
            // Zuweisung mit this.
            this.game = game;
        }
        public int leben = 1000;
        public void LookAround(string input, string umsehenText)
        {
            if (input == "umsehen")
            {
                Console.WriteLine(umsehenText);
            }
        }
        public int Move(int intNewEnvi)
        {
            game.envi = intNewEnvi;
            game.countLocation = 0;
            Console.Clear();
            return game.envi;
        }
        public void LookAt(string input, string itemName, string ansehenText)
        {
            if (input.Contains("ansehen " + itemName))
            {
                if (Inventar.Contains(itemName))
                {
                    Console.WriteLine("'{0}' befindet sich bereits in deinem Inventar.", itemName);
                }
                else
                {
                    Console.WriteLine(ansehenText);
                }
            }
        }
        public void InventarCall(string input, List<string> Inventar)
        {
            if (input == "Inventar")
            {
                Console.WriteLine("Inventar:");
                if (Inventar.Count == 0)
                {
                    Console.WriteLine("leer");
                }
                else
                {
                    foreach (string element in Inventar)
                    {
                        Console.WriteLine(element);
                    }
                }
            }
        }
    }
}
