using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Speler
    {
        public static List<Kaart> spelerDeck = new List<Kaart>();
        //public static List<Kaart> Hand = new List<Kaart>();
        public string Naam { get; set; }
        public int Waarde { get { int totaalWaarde = 0; 
                foreach (var kaart in spelerDeck)
                    totaalWaarde += kaart.Nummer;
                return totaalWaarde;
            } }

        
        public bool EersteBeurt = true;

        public void SpelerDeck()
        {
            if (EersteBeurt == true)
            {
                var kaart1 = Spel.kaartenStack.Pop();
                var kaart2 = Spel.kaartenStack.Pop();
                spelerDeck.Add(kaart1);
                spelerDeck.Add(kaart2);
                Console.WriteLine("Je hebt een " + spelerDeck[spelerDeck.Count - 1] + " en een " + spelerDeck[spelerDeck.Count - 2] + " gekregen. Het totaal in je hand is " + Waarde + ".");
            }
            /*else if (EersteBeurt != true)
            {
                var kaart1 = Spel.kaartenStack.Pop();
                spelerDeck.Add(kaart1);
                Console.WriteLine("Je hebt een " + spelerDeck[spelerDeck.Count - 1] + " en een " + spelerDeck[spelerDeck.Count - 2] + " gekregen. Het totaal in je hand is " + Waarde + ".");
            }*/
        }
    }
}
