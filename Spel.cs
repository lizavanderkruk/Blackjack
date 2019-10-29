using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack;
using Blackjack.Database;
using Blackjack.Repositories;

namespace Blackjack
{
    public class Spel
    {
        static public List<Speler> Spelertjes = new List<Speler>();
        public static List<Kaart> Kaarten = new List<Kaart>();
        public static Stack<Kaart> kaartenStack = new Stack<Kaart>();
        private speler_db spelerRepo = new speler_db();

        Dealer dealer = new Dealer();
        //Speler speler = new Speler(speler);
        public Speler activePlayer;

        public bool playActief = true;
        public bool EersteBeurt = true;
        public bool LaatsteKaartGepakt = true;
        public string input = "";
        private static string[] kleuren = new string[4] { "Harten", "Ruiten", "Klaveren", "Schoppen" };

        public void StartSpel()
        {
            Console.WriteLine("Welkom bij Blackjack!");
            Console.WriteLine("Wat is je naam Speler?");
            string inputnaam = Console.ReadLine();
            CheckNaamDb(inputnaam);
            SpelerToevoegen(inputnaam);

            KaartspelMaken();
            StackBouwen();
            Console.WriteLine("Druk op 'k' om een kaart te vragen.");

            activePlayer = Spelertjes[0];
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
        public void CheckNaamDb(string naam)
        {
            bool BestaatAl = false;
            foreach (spelers speler in spelerRepo.GetSpelers())
            {
                if (naam == speler.speler_naam)
                {
                    BestaatAl = true;
                    Console.WriteLine("Deze persoon bestaat al.");
                    Console.ReadKey();
                }
            }
            if (BestaatAl == false)
            {
                var newPlayer = new spelers();
                newPlayer.speler_naam = naam;
                spelerRepo.AddNewSpeler(newPlayer);
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
                Console.WriteLine("Je hebt een " + Speler.spelerDeck[Speler.spelerDeck.Count - 1] + " en een " + Speler.spelerDeck[Speler.spelerDeck.Count - 2] + " gekregen. Het totaal in je hand is " + activePlayer.Waarde + ".");
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
                if (activePlayer.Waarde< 21)
                {
                    EersteBeurt = false;
                    var kaart1 = Spel.kaartenStack.Pop();
                    Speler.spelerDeck.Add(kaart1);
                    Console.WriteLine("Je hebt een " + Speler.spelerDeck[Speler.spelerDeck.Count - 1] + " gekregen.Het totaal in je hand is " + activePlayer.Waarde + ".");
                    input = Console.ReadLine();
                }
                if (activePlayer.Waarde == 21 && playActief == true)
                {
                    Console.WriteLine("Je hebt Blackjack");
                    playActief = false;
                    Console.ReadKey();
                }
                if(activePlayer.Waarde > 21 && playActief == true)
                {
                    Console.WriteLine("Je hebt verloren");
                    playActief = false;
                    Console.ReadKey();
                }
            }
            while (activePlayer.Waarde <=21 && playActief == true);
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
        public void SpelerToevoegen(string Naam)
        {
            Speler spelerNaam = new Speler(Naam);
            Spelertjes.Add(spelerNaam);
        }
    }
}




            
            

            
            
 
                
       
    
