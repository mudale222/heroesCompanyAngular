using heroesCompanyAngular.Data;
using heroesCompanyAngular.Data.EFCore;
using heroesCompanyAngular.dto;
using heroesCompanyAngular.Models;
using Md_exercise.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.ControllersServices {
    //public class HeroRepository : EfCoreRepository<Hero>, IHeroRepository {

    public class AccountRepository : EfCoreRepository<ApplicationUser>, IAccount {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        public  SignInManager<ApplicationUser> signManager { get; }

        public AccountRepository(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signManager
            ) : base(context) {
            this.userManager = userManager;
            this.context = context;
            this.signManager = signManager;
        }
        public async Task<Response> Create(ApplicationUserDto registrtionData) {
            var userInDb = context.Users.FirstOrDefault(x => x.UserName == registrtionData.name);
            if (registrtionData is not null && userInDb is null) {
                var user = new ApplicationUser { UserName = registrtionData.name, Email = registrtionData.email };
                var result = await userManager.CreateAsync(user, registrtionData.password);
                if (result.Succeeded)
                    return new Response { IsSuccessed = true };
            }
            return new Response { IsSuccessed = false };
        }

    }
}
