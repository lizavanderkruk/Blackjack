using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij BlackJack");
            Console.ReadKey();
            Spel _spel = new Spel();
            _spel.KaartspelMaken();
            Console.ReadKey();
        }
    }
}
