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
        static public List<Kaart> Kaarten = new List<Kaart>();
        private string[] kleuren = new string[4] { "Harten", "Ruiten", "Klaveren", "Schoppen" };
        public Spel()
        {
            KaartspelMaken();
            Console.ReadLine();
        }

        public List<Kaart> KaartspelMaken()
        {
            foreach (var kleur in kleuren)
            {
                for (int i = 2; i < 11; i++)
                {
                    Kaarten.Add(new Kaart(i, kleur));
                }
                Kaarten.Add(new Plaatjeskaart(kleur, "Boer"));
                Kaarten.Add(new Plaatjeskaart(kleur, "Koningin"));
                Kaarten.Add(new Plaatjeskaart(kleur, "Koning"));
                Kaarten.Add(new Aas(kleur, "Aas"));
            }
        
            Kaarten = Kaarten.Randomize();
            return Kaarten;


           /* for (int i = 0; i < 52; i++)
            {                
                Console.WriteLine(Kaarten[i]);
                //Console.ReadKey();
            }
            */


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
 
                
       /* public void Starten()
        {
            //Console.WriteLine("hallo");
            //Kaart.KaartTrekken(); 
        }*/
    
