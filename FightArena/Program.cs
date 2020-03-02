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
        public static List<SuperHeros> Heros = new List<SuperHeros>();
        static void Main(string[] args)
        {

            CreatingHero();


        }

        static void CreatingHero()
        {
            Heros.Add(new SuperHeros("Kong fu Harry", 2, 5, 120));
            Heros.Add(new SuperHeros("Super hunden dino", SuperHeros.SettingAttackRange(), SuperHeros.SettingDefenceRange(), 70));
            Heros.Add(new SuperHeros("Hurtig Karl", 5, 3, 90));
            Heros.Add(new SuperHeros("Gift Gunner", SuperHeros.SettingAttackRange(), 5, 60));
            Heros.Add(new SuperHeros("Minimusen Mikkel ", 9, 9, 40));
            Heros.Add(new SuperHeros("Katten Tiger", SuperHeros.SettingAttackRange(), 4, SuperHeros.AddingHP()));
            Heros.Add(new SuperHeros("Gummigeden Ivan", 6, 8, 70));
            Heros.Add(new SuperHeros("elgen Egon", SuperHeros.SettingAttackRange(), 4, 90));

        }

        void GenreateFightList()
        {
         Random random = new Random();

        }
    }
}
