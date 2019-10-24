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

        public bool playActief = true;
        public bool EersteBeurt = true;
        public bool LaatsteKaartGepakt = true;
        public string input = "";
        private static string[] kleuren = new string[4] { "Harten", "Ruiten", "Klaveren", "Schoppen" };

        public void StartSpel()
        {
            KaartspelMaken();
            Console.WriteLine("Druk op 'k' om een kaart te vragen.");
            StackBouwen();
            SpelerDeck();
            DealerDeck();
            EersteBeurt = false;

            while (playActief == true)
            {
                input = Console.ReadLine();
                if (input == "k")
                {
                    SpelerDeck();
                    DealerDeck();
                    SpelSpelen(); 
                }
                else if (input == "p")
                {
                    Console.WriteLine("Je wilt passen.");
                    EersteBeurt = false;
                    DealerDeck();
                }
                else if (playActief == true)
                {
                    Console.WriteLine("Verkeerde invoer, klik op 'k' voor een kaart.");
                    input = Console.ReadLine();
                }
            }
        }
        public void SpelerDeck()
        {
            if (EersteBeurt == true)
            {
                var kaart1 = Spel.kaartenStack.Pop();
                var kaart2 = Spel.kaartenStack.Pop();
                Speler.spelerDeck.Add(kaart1);
                Speler.spelerDeck.Add(kaart2);
                Console.WriteLine("Je hebt een " + Speler.spelerDeck[Speler.spelerDeck.Count - 1] + " en een " + Speler.spelerDeck[Speler.spelerDeck.Count - 2] + " gekregen. Het totaal in je hand is " + speler.Waarde + ".");
                //EersteBeurt = false;
            }
            else
            {
                SpelSpelen();
            }
            
        }
        public void DealerDeck()
        {
            if (EersteBeurt == true)
            {
                var kaart1 = Spel.kaartenStack.Pop();
                Dealer.dealerDeck.Add(kaart1);
                Console.WriteLine("De dealer heeft een " + Dealer.dealerDeck[Dealer.dealerDeck.Count - 1] + " gekregen. Het totaal van de dealer is " + dealer.Waarde + ".");
            }
            if (EersteBeurt != true && playActief == true)
            {
                var kaart1 = Spel.kaartenStack.Pop();
                Dealer.dealerDeck.Add(kaart1);
                Console.WriteLine("De dealer heeft een " + Dealer.dealerDeck[Dealer.dealerDeck.Count - 1] + " gekregen. Het totaal van de dealer is " + dealer.Waarde + ".");
            }
        }
        public void SpelSpelen()
        {            
            do
            {
                if (speler.Waarde< 21)
                {
                    EersteBeurt = false;
                    var kaart1 = Spel.kaartenStack.Pop();
                    Speler.spelerDeck.Add(kaart1);
                    Console.WriteLine("Je hebt een " + Speler.spelerDeck[Speler.spelerDeck.Count - 1] + " gekregen.Het totaal in je hand is " + speler.Waarde + ".");
                    input = Console.ReadLine();
                }
                if (speler.Waarde == 21 && playActief == true)
                {
                    Console.WriteLine("Je hebt Blackjack");
                    playActief = false;
                    Console.ReadKey();
                }
                if(speler.Waarde > 21 && playActief == true)
                {
                    Console.WriteLine("Je hebt verloren");
                    playActief = false;
                    Console.ReadKey();
                }
            }
            while (speler.Waarde <=21 && playActief == true);
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
            //Console.ReadKey();
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




            
            

            
            
 
                
       
    
