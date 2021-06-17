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
    }
}
