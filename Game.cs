using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreat
{
    class Game
    {
        Item glas;
        Item rippe;
        Item quadratRippe;
        Player player;
        NPC amalia;
        public int envi = 0;
        public int countLocation = 0;

        string input;

        bool TürHütteClosed = true;
        public void Run()
        {
            // this an den Konstruktor übergeben
            player = new Player(this);
            glas = new Item("Glas", player);
            rippe = new Item("Rippe", player);
            quadratRippe = new Item("Quadratische Rippe", player);
            amalia = new NPC("Amalia");
            while (true)
            {
                while (player.leben == 1000)
                {
                    if (envi == 0 && countLocation == 0)
                    {
                        Console.WriteLine("Du bist bei den Felsen.");
                        countLocation++;
                    }
                    else if (envi == 1 && countLocation == 0)
                    {
                        Console.WriteLine("Du bist am Strand.");
                        countLocation++;
                    }
                    else if (envi == 2 && countLocation == 0)
                    {
                        Console.WriteLine("Du bist im Jungle.");
                        countLocation++;
                    }
                    else if(envi == 3 && countLocation == 0)
                    {
                        if(TürHütteClosed == false)
                        {
                            Console.WriteLine("Du bist in der Hütte.");
                            countLocation++;
                        }
                        if(TürHütteClosed == true)
                        {
                            Console.WriteLine("Die 'Tür' der Hütte ist zugesperrt und du kommst nicht hinein.");
                            countLocation++;
                        }
                    }
                    else if(envi == 4 && countLocation == 0)
                    {
                        Console.WriteLine("Du bist auf der Lichtung im Jungle.");
                        countLocation++;
                    }
                    input = Console.ReadLine();
                    player.InventarCall(input, player.Inventar);
                    switch (envi)
                    {
                        case 0:   // FELSEN UMEGEBUNG
                            // Umsehen
                            player.LookAround(input, "Du siehst dich bei den 'Felsen' um und entdeckst ein 'Skelett' eines Tieres und ein 'glänzendes etwas', das ihm an den 'Rippen' hängt. In der Ferne ist der unendliche" + Environment.NewLine +
                                " 'Jungle' zu sehen und du erblickst den 'Strand'. Da solltest du vielleicht mal hin'gehen'.");
                            // Ansehen
                            player.LookAt(input, "Felsen", "Ein paar Felsen, grau in grau.");
                            player.LookAt(input, "Skelett", "Du siehst dir das Skelett an und es ist komplett abgenagt. Wohl schon länger tot.");
                            player.LookAt(input, "glänzendes etwas", "Es ist ein Stück 'Glas', das sehr spitzkantig ist, vielleicht solltest du es mit'nehmen'.");
                            player.LookAt(input, "Rippen", "Du siehst dir die Rippen genauer an und bemerkst das eine fehlt. Du entdeckst sie zwischen den Felsen liegen.");
                            // Ansehen Pickupables
                            player.LookAt(input, "Glas", "Ein Stück Weißglas das sich bestimmt ausgezeichnet zum schnitzen eignet.");
                            player.LookAt(input, "Rippe", "Die 'Rippe' die du entdeckt hast ist in der hälfte abgebrochen und noch sehr stumpf und zu wenig zu gebrauchen.");
                            // Aufheben Funktionen
                            glas.PickUp(input);
                            rippe.PickUp(input);
                            // Bewegen möglich machen
                            if (input.Contains("gehen"))
                            {
                                if (input.Contains("Strand"))
                                {
                                    player.Move(1);
                                }else if (input.Contains("Jungle"))
                                {
                                    player.Move(2);
                                }else
                                {
                                    Console.WriteLine("Tut mir leid da kann ich nicht hingehen. Das ist zu weit weg.");
                                }
                            }
                            break;



                        case 1:  // Strand Umgebung
                            // Umsehen
                            player.LookAround(input, "Hier am Strand ist ganz viel 'Sand', ein 'Fass' und eine 'Hütte'.");
                            // Ansehen Funktionen
                            player.LookAt(input, "Sand", "Im Sand ist nicht viel interessantes. Ein paar Muscheln.");
                            player.LookAt(input, "Fass", "Ein 'dubioses Fass' mit einem roten 'Totenkopf' darauf.");
                            player.LookAt(input, "dubioses Fass", "Du riechst an dem 'Fass' und es riecht nach einer Mischung aus Eichenholz, Schwarzpulver und Schnapps.");
                            player.LookAt(input, "Hütte", "Die 'Hütte' ist zu weit weg, du solltest mal hingehen.");
                            player.LookAt(input, "Totenkopf", "Ein roter Totenkopf, der aus irgendeinem Grund Rastalocken hat...");
                            // Bewegen möglich machen
                            if (input.Contains("gehen"))
                            {
                                if(input.Contains("Hütte"))
                                {
                                    player.Move(3);
                                }else if (input.Contains("Felsen"))
                                {
                                    player.Move(0);
                                }else if (input.Contains("Jungle"))
                                {
                                    player.Move(2);
                                }else
                                {
                                    Console.WriteLine("Tut mir leid da kann ich nicht hingehen. Das ist zu weit weg.");
                                }
                            }
                            break;



                        case 2:   // Jungle Umgebung
                            // Umsehen
                            player.LookAround(input, "Du stehst inmitten eines dicht gewachsenen Jungles und hörst aus der Nähe von einer 'Lichtung' einen Schrei.");
                            // Ansehen Funktionen 
                            player.LookAt(input, "Lichtung", "In Richtung Lichtung ist ein Weg frei geschlagen.");
                            if (input.Contains("gehen"))
                            {
                                if (input.Contains("Strand"))
                                {
                                    player.Move(1);
                                }else if (input.Contains("Felsen"))
                                {
                                    player.Move(0);
                                }else if(input.Contains("Lichtung"))
                                {
                                    player.Move(4);
                                }else if(input.Contains("Hütte"))
                                {
                                    player.Move(3);
                                }
                                else
                                {
                                    Console.WriteLine("Tut mir leid da kann ich nicht hingehen. Das ist zu weit weg.");
                                }
                            }
                            break;



                        case 3:   // Hütte Umgebung
                            if(TürHütteClosed == true)
                            {
                                //Umsehen
                                player.LookAround(input, "Die 'Tür' hat anstatt einer Türklinke nur ein quadratisches 'Loch'.");
                                // Ansehen Funktionen
                                player.LookAt(input, "Tür", "Eine schwere Holztür ohne Türgriff.");
                                player.LookAt(input, "Loch", "Wenn du etwas findest was die selbe 'quadratische Form' hat wie das Loch, kannst du sie vielleicht öffnen!");
                                player.LookAt(input, "quadratische Form", "Alle Seiten sind gleich lang. Das solltest du ja wohl wissen.");
                                //Benutzen Knochen
                                TürHütteClosed = quadratRippe.Use(input, quadratRippe.itemName, "Die Tür ist auf und du kannst jetzt in die Hütte gehen.", TürHütteClosed);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Du bist in der Hütte.");
                            }
                            // Bewegen möglich machen
                            if (input.Contains("gehen"))
                            {
                                if (input.Contains("Strand"))
                                {
                                    player.Move(1);
                                }
                                else if (input.Contains("Felsen"))
                                {
                                    player.Move(0);
                                }
                                else if (input.Contains("Jungle"))
                                {
                                    player.Move(2);
                                }
                                else
                                {
                                    Console.WriteLine("Tut mir leid da kann ich nicht hingehen. Das ist zu weit weg.");
                                }
                            }
                            break;



                        case 4: // Lichtung Umgebung
                            // Umsehen
                            player.LookAround(input, "Du stehst mitten in einem Camp von 'Siedler'n. Überall 'Zelte' und in der Mitte der Lichtung brennt ein großes 'Feuer'. Es ist aber im Moment nur eine 'Frau' da.");
                            // Ansehen Funktionen
                            player.LookAt(input, "Siedler", "Die Menschen die diesen seltsamen Ort bewohnen scheinen friedlich zu sein. Nirgends Waffen zu sehen. Aber woher kam dann der Schrei?");
                            player.LookAt(input, "Zelte", "Diese sogenannten Zelte sind eigentlich nur große 'Blätter' die von Ästen gestützt werden.");
                            player.LookAt(input, "Feuer", "Das Feuer das in der Mitte der Lichtung brennt erfüllt nicht wirklich einen Zweck, ist wohl zur Abschreckung von wilden Tieren gedacht.");
                            player.LookAt(input, "Frau", "Die 'Frau' die du entdeckt hast scheint gerade beschäftigt zu sein. Vielleicht würde es sich lohnen mit ihr zu 'sprechen'.");
                            // Gespräch Frau
                            if(input == "sprechen Frau")
                            {
                                bool firstContact = false;
                                amalia.Communicate("A: Wie heißt du?", "B: Woher kam der Schrei?", string.Empty, "Mein Name ist " + amalia.npcName, "Ich habe mich geschnitten.", string.Empty, firstContact);
                            }
                            // Bewegen möglich machen
                            if (input.Contains("gehen"))
                            {
                                if (input.Contains("Jungle"))
                                {
                                    player.Move(2);
                                }
                                else
                                {
                                    Console.WriteLine("Tut mir leid da kann ich nicht hingehen. Das ist zu weit weg.");
                                }
                            }
                            break;

                        case 41: // Lichtung Gespräch Frau
                            //string textA;
                            //string textB;
                            //string textC;
                            //textA = "'A' : Hallo... Wie ist dein Name?";
                            //textB = "'B' : Woher kam der Schrei?";
                            //textC = "'C' : Was machst du da?";
                            //while (envi == 41)
                            //{
                            //    int counterGespräch = 1;
                            //    if (counterGespräch == 1)
                            //    {
                            //        if (textA == string.Empty && textB == string.Empty && textC == string.Empty)
                            //        {
                            //            textA = "'A' : Du hast geschnitzt? Kannst du mir da vielleicht mit was helfen?";
                            //            counterGespräch++;
                            //        }
                            //        else
                            //        {
                            //            if (countLocation == 0)
                            //            {
                            //                Console.WriteLine("Du unterhältst dich mit der Frau.");
                            //                countLocation++;
                            //            }
                            //            Console.WriteLine("Du:");
                            //            Console.WriteLine(textA);
                            //            Console.WriteLine(textB);
                            //            Console.WriteLine(textC);
                            //            input = Console.ReadLine();
                            //            if (input == "A" | input == "a")
                            //            {
                            //                Console.WriteLine("Sie:");
                            //                Console.WriteLine("Mein Name ist Amalia. Ich hab jetzt keine Zeit.");
                            //                textA = string.Empty;
                            //            }
                            //            if (input== "B" | input == "b")
                            //            {
                            //                Console.WriteLine("Sie:");
                            //                Console.WriteLine("Siehst du das nicht??? Ich hab mich geschnitten.");
                            //                textB = string.Empty;
                            //            }
                            //            if (input == "C" | input == "c")
                            //            {
                            //                Console.WriteLine("Sie:");
                            //                Console.WriteLine("Ich habe grade geschnitzt. Und jetzt unterhalte ich mich mit einem Idioten.");
                            //                textC = string.Empty;
                            //            }
                            //        }
                            //    }                                
                            //    if(counterGespräch == 2)
                            //    {
                            //        Console.WriteLine("Du:");
                            //        Console.WriteLine(textA);
                            //        input = Console.ReadLine();
                            //        if (input == "A" | input == "a")
                            //        {
                            //            Console.WriteLine("Sie:");
                            //            Console.WriteLine("Ja von mir aus. Womit denn?");
                            //            textA = string.Empty;
                            //        }

                            //        if (textA == string.Empty)
                            //        {
                            //            counterGespräch++;
                            //            textA = "'A' : Ich habe hier einen Knochen gefunden. Kannst du mir vielleicht eine Seite Quadratisch schnitzen?";
                            //        }
                            //    }
                            //    if(counterGespräch == 3)
                            //    {
                            //        Console.WriteLine("Du:");
                            //        Console.WriteLine(textA);
                            //        input = Console.ReadLine();
                            //        if (input == "A" | input == "a")
                            //        {
                            //            Console.WriteLine("Sie:");
                            //            Console.WriteLine("Also gut. Hier bitte. Jetzt hast du eine 'Quadratische Rippe'.");
                            //            player.Inventar.Add(quadratRippe.itemName);
                            //        }
                            //        if (player.Inventar.Contains(quadratRippe.itemName))
                            //        {
                            //            player.Inventar.Remove(rippe.itemName);
                            //            Console.WriteLine("Jetzt lass mich aber in Ruhe!");
                            //            envi = 4;
                            //            countLocation = 0;
                            //        }
                            //    }
                            //}
                            break;
                    }
                }
            }
        }
    }
}
