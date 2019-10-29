using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Database;
using Blackjack.Repositories;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            speler_db spelerRepo = new speler_db();

            foreach (spelers speler in spelerRepo.GetSpelers())
            {  
                foreach (var sessy in speler.sessies)
                {
                    Console.WriteLine($"Speler {speler.speler_naam} speelt het volgende spel: {sessy.Spellen.spel_naam}"); 
                    //Console.WriteLine(sessy.Spellen.spel_naam);
                }
            }
            
            Spel _spel = new Spel();
            _spel.StartSpel();
            //Console.ReadKey();
   
        }
    }
}
