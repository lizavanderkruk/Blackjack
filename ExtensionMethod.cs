using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public static class ExtensionMethod
    {
        public static List<Kaart> Randomize (this IList<Kaart> list)
        {
            List<Kaart> Kaarten = new List<Kaart>();
            Random rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Kaart value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return Kaarten;
    }
}
}
