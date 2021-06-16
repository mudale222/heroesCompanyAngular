using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using heroesCompanyAngular.dto;
using heroesCompanyAngular.Models;
using heroesCompanyAngular.Models.HelperModels;

namespace heroesCompanyAngular.DataAccess.Heros {
    public interface IHeroRepository {
        Hero[] GetAll4User(ClaimsPrincipal User);
        Task<Hero> Remove(CardId cardIdClass, ClaimsPrincipal User);
        Task<Hero> Train(CardId cardIdClass);
        Task<Hero> Create(HeroDto heroData, ClaimsPrincipal User);
    }
}

