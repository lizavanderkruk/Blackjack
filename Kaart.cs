using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Kaart
    {
        public int Nummer { get; set; }
        public string Kleur { get; set; }
        public bool Gepakt { get; set; }
        public int Count { get; set; }

        public Kaart(int nummer, string kleur)
        {
            this.Nummer = nummer;
            this.Kleur = kleur;
            this.Gepakt = false;
            this.Count = 0;
        }

        public override string ToString()
        {
            return $"{Kleur} {Nummer}";
        }
    }
    
    public class Plaatjeskaart: Kaart
    {
        public Plaatjeskaart(string kleur, string naam): base(10, kleur)
        {
            Naam = naam;
        }
        public string Naam { get; set; }
        public override string ToString()
        {
            return $"{Kleur} {Naam}";
        }
    }
    public class Aas: Kaart
    {
        public Aas(string kleur, string naam): base (11, kleur)
        {
            Naam = naam;
        }
        public string Naam { get; set; }
        public override string ToString()
        {
            return $"{Kleur} {Naam}";
        }
    }
}

        
     

    
