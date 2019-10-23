using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack;

namespace Blackjack
{
    public class Spel
    {
        public static List<Kaart> Kaarten = new List<Kaart>();
        public static Stack<Kaart> kaartenStack = new Stack<Kaart>();
        Dealer dealer = new Dealer();
        Speler speler = new Speler();

        bool playActief = true;
        
        string input = "";
        private static string[] kleuren = new string[4] { "Harten", "Ruiten", "Klaveren", "Schoppen" };
        public Spel()
        {
            KaartspelMaken();
            Console.WriteLine("Druk op 'k' om een kaart te vragen."); 
            StackBouwen();
            speler.SpelerDeck();
            dealer.DealerDeck();
            speler.EersteBeurt = false;

            while (playActief == true)
            { 
                input = Console.ReadLine();
                if (input == "k")
                {
                    speler.SpelerDeck();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Verkeerde invoer, klik op 'k' voor een kaart.");
                    input = Console.ReadLine();
                }
            }
        }
        public static void KaartspelMaken()
        {
            foreach (var kleur in kleuren)
            {
                for (int i = 2; i < 11; i++)
                {
                    Kaarten.Add(new Kaart(i, kleur, i));
                }
                Kaarten.Add(new Plaatjeskaart(kleur, "Boer"));
                Kaarten.Add(new Plaatjeskaart(kleur, "Koningin"));
                Kaarten.Add(new Plaatjeskaart(kleur, "Koning"));
                Kaarten.Add(new Aas(kleur, "Aas"));
            }
            Kaarten.Randomize();
            Console.ReadKey();
        }

        public static void StackBouwen()
        {
            for (int i = 0; i < 52; i++)
            {
                kaartenStack.Push(Kaarten[i]);
                //Console.WriteLine("(Pop)\t\t{0}", kaartenStack.Pop());
            }
            Console.ReadLine();
        } 
    }
}




            
            

            
            /*for (int x = 0; x < nummers.Length; x++)
            {
                for (int y = 0; y < kleuren.Length; y++)
                {
                    kaarten.Add(new Kaart(nummers[x], kleuren[y]));
                }
            }
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(kaarten[i]);
                Console.ReadKey();
            }
            Console.ReadLine();
        }*/
 
                
       
    
