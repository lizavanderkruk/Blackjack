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
        public string Naam { get; set; }
        public int Waarde
        {
            get
            {
                int totaalWaarde = 0;
                foreach (var kaart in spelerDeck)
                    totaalWaarde += kaart.Nummer;
                return totaalWaarde;
            }
        }
    }
}


