using Blackjack.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Repositories
{
    public class speler_db
    {
        private SpellenEntities1 context = new SpellenEntities1();

        public IEnumerable<spelers> GetSpelers()
        {
            return context.spelers1.AsEnumerable();
        }
        /*public IEnumerable<sessy> GetSpellen()
        {
            return context.spelers1.AsEnumerable();
        }*/

        public spelers GetSpelerByName(string name)
        {
            return context.spelers1.Single(s => s.speler_naam == name);
        }
        public void AddNewSpeler(spelers spelers)
        {
            context.spelers1.Add(spelers);
            context.SaveChanges();
        }
    }
}
