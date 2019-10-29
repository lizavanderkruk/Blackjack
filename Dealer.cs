using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer
    {
        //Speler speler = new Speler();
        public string Naam { get; set; }
        public int Waarde { get { int totaalWaarde = 0;
                foreach (var kaart in dealerDeck)
                    totaalWaarde += kaart.Nummer;
                return totaalWaarde; }}

        public static List<Kaart> dealerDeck = new List<Kaart>();
        
        
    }
}
