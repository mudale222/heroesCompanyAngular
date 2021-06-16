using heroesCompanyAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular {
    public static class Uti {
        public static decimal Add10PrecentOrLess(decimal num) {
            Random random = new Random();
            if (num < 10)
                num = num + (decimal)random.Next(1, (int)num * 10) / (decimal)100;
            else
                num = num + (decimal)random.Next(1, (int)num) / (decimal)10;
            return num;
        }

        public static void TrainHero(Hero hero) {
            hero.TrainedCount++;
            hero.TrainedDate = DateTime.Now;
            hero.CurrentPower = Uti.Add10PrecentOrLess(hero.CurrentPower);
        }

        public static bool IsCanTrain(Hero hero) {
            if (hero.TrainedDate.Day != DateTime.Now.Day)
                hero.TrainedCount = 0;
            if (hero.TrainedCount < 5)
                return true;
            return false;
        }
    }
}
