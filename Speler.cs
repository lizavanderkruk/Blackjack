using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Speler
    {
        public string name;
        public static List<Kaart> spelerDeck = new List<Kaart>();

        public Speler(string speler)
        {
            name = speler;
        }
        public string Naam { get { return name; } }
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
