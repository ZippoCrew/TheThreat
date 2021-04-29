using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreat
{
    class NPC
    {
        public string npcName;
        public NPC(string npcName)
        {
            this.npcName = npcName;
        }
        public void Communicate(string answerOne, string answerTwo, string answerThree, string responseOne, string responseTwo, string responseThree, bool gespräch)
        {
            Console.Clear();
            Console.WriteLine("(Um die Unterhaltung zu beenden, sag einfach 'byebye' oder 'bb'!)");
            Console.WriteLine("Dialogoptionen:");
            Console.WriteLine(answerOne);
            if (answerTwo != string.Empty)
            {
                Console.WriteLine(answerTwo);
            }
            if (answerThree != string.Empty)
            {
                Console.WriteLine(answerThree);
            }
            gespräch = true;
            while(gespräch)
            {
                string input = Console.ReadLine();
                if (input == "a" | input == "A")
                {
                    Console.WriteLine(npcName + ": " + responseOne);
                }
                if (input == "b" | input == "B" && answerTwo != string.Empty)
                {
                    Console.WriteLine(npcName + ": " + responseTwo);
                }
                if (input == "c" | input == "C" && answerThree != string.Empty)
                {
                    Console.WriteLine(npcName + ": " + responseThree);
                }
                else if (input == "bb" || input == "byebye")
                {
                    Console.WriteLine(npcName + ": Tschüss!");
                    gespräch = false;
                }
            }
        }
    }
}
