using heroesCompanyAngular.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using heroesCompanyAngular.Data.EFCore;
using System.Security.Claims;
using heroesCompanyAngular.Models.HelperModels;
using heroesCompanyAngular.dto;
using AutoMapper;
using heroesCompanyAngular.DataAccess.Heros;

namespace heroesCompanyAngular.Data {
    public class HeroRepository : EfCoreRepository<Hero>, IHeroRepository {
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public HeroRepository(ApplicationDbContext context, IMapper mapper) : base(context) {
            this.context = context;
            _mapper = mapper;
        }

        public Hero[] GetAll4User(ClaimsPrincipal User) {
            return context.Heroes.
                Where(hero => hero.Trainer.UserName == User.Identity.Name).
                OrderByDescending(x => x.CurrentPower).
                ToArray();
        }

        public async Task<Hero> Remove(CardId cardIdClass, ClaimsPrincipal User) {
            var heroToDelete = context.Heroes.Where(hero =>
                (hero.Id == new Guid(cardIdClass.Id) && hero.Trainer.UserName == User.Identity.Name)).ToArray();
            if (heroToDelete.Count() > 0) {
                var heroRemoved = context.Heroes.Remove(heroToDelete[0]);
                await context.SaveChangesAsync();
                return heroRemoved.Entity;
            }
            return null;
        }

        public async Task<Hero> Train(CardId cardIdClass) {
            var hero = context.Heroes.FirstOrDefault(hero => (hero.Id == new Guid(cardIdClass.Id)));
            Uti.TrainHero(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<Hero> Create(HeroDto heroData, ClaimsPrincipal User) {
            var heroMapped = _mapper.Map<HeroDto, Hero>
                (heroData, opt => opt.AfterMap(
                (src, dest) => dest.Trainer = context.Users.FirstOrDefault
                (x => x.UserName == User.Identity.Name)
                ));
            var hero = context.Heroes.Add(heroMapped);
            await context.SaveChangesAsync();
            return hero.Entity;
        }

    }
}
