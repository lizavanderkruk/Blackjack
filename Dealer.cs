using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer
    {
        public string Naam { get; set; }
        public int Waarde { get { int totaalWaarde = 0;
                foreach (var kaart in dealerDeck)
                    totaalWaarde += kaart.Nummer;
                return totaalWaarde; }}

        public static List<Kaart> dealerDeck = new List<Kaart>();
        Speler speler = new Speler();

        public void DealerDeck()
        {
            if (speler.EersteBeurt == true)
            {
                var kaart1 = Spel.kaartenStack.Pop();
                dealerDeck.Add(kaart1);
                Console.WriteLine("De dealer heeft een " + dealerDeck[dealerDeck.Count - 1] + " gekregen. Het totaal van de dealer is " + Waarde + ".");
            }
        }
    }
}
