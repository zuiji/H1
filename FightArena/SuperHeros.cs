using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class SuperHeros
    {

        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int Defence { get; set; }
        public int HitPoints { get; set; }


        public SuperHeros(string name, int attackPower, int defence, int hitPoints)
        {
            Name = name;
            AttackPower = attackPower;
            Defence = defence;
            HitPoints = hitPoints;
        }

        public SuperHeros(string name, int defence, int hitPoints)
        {
            Name = name;
            AttackPower = SettingAttackRange();
            Defence = defence;
            HitPoints = hitPoints;
        }

        public SuperHeros(string name, int hitPoints)
        {
            Name = name;
            AttackPower = SettingAttackRange();
            Defence = SettingDefenceRange();
            HitPoints = hitPoints;
        }
      
        public int SettingAttackRange()
        {
            if (Name == "Super hunden dino")
            {
                Random ran = new Random();
                AttackPower = ran.Next(6, 8);

            }
            else if (Name == "Hurtig Karl")
            {
                int KarlAttak = 5;
                int resentAttack = KarlAttak;
                if (resentAttack == 5)
                {
                    AttackPower = KarlAttak = 2;
                }
                else AttackPower = KarlAttak = 5;
            }

            if (Name == "Giftig Gunner")
            {
                Random ran = new Random();
                AttackPower = ran.Next(1, 13);
            }
            else if (Name == "Elgen Egon")
            {
                Random ran = new Random();
                AttackPower = ran.Next(5, 11);
            }

            return AttackPower;
        }

        public int SettingDefenceRange()
        {
            if (Name == "Super hunden dino")
            {
                Random random = new Random();
                Defence = random.Next(2, 8);
            }

            return Defence;
        }

        public int AddingHP()
        {
            if (Name == "Katten Tiger")
            {
                HitPoints = 35;
                int lifeCount = 0;
                if (lifeCount < 9)
                {
                    HitPoints += 3;
                    lifeCount++;
                }
            }
            return HitPoints;
        }

    }
}
