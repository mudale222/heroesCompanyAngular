using heroesCompany.dto;
using heroesCompany.Models;
using heroesCompany.Models.HelperModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace heroesCompany.DataAccess.Heros {
    public interface IHeroRepository {
        Hero[] GetAll4User(ClaimsPrincipal User);
        Task<Hero> Remove(CardId cardIdClass, ClaimsPrincipal User);
        Task<Hero> Train(CardId cardIdClass);
        Task<Hero> Create(HeroDto heroData, ClaimsPrincipal User);
    }
}

