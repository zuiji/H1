using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class Program
    {
      
        static void Main(string[] args)
        {
            List<SuperHeros> Heros = new List<SuperHeros>();

            CreatingHero(Heros);
            foreach (SuperHeros superHerose in Heros)
            {
                Console.WriteLine($"{superHerose.Name} {superHerose.AttackPower} {superHerose.Defence} {superHerose.HitPoints}");
            }
        }

       static  void CreatingHero(List<SuperHeros> Heros)
        {
            Heros.Add(new SuperHeros("Kong fu Harry", 2, 5, 120));
            Heros.Add(new SuperHeros("Super hunden dino", 70));
            Heros.Add(new SuperHeros("Hurtig Karl", 5, 3, 90));
            Heros.Add(new SuperHeros("Gift Gunner", 5, 60));
            Heros.Add(new SuperHeros("Minimusen Mikkel ", 9, 9, 40));
            Heros.Add(new SuperHeros("Katten Tiger", 4, 4));
            Heros.Add(new SuperHeros("Gummigeden Ivan", 6, 8, 70));
            Heros.Add(new SuperHeros("elgen Egon", 4, 90));

        }

        void GenreateFightList()
        {
         Random random = new Random();

        }
    }
}
