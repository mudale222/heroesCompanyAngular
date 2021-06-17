using heroesCompanyAngular.Data;
using heroesCompanyAngular.dto;
using heroesCompanyAngular.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.ControllersServices {
    public class Account : IAccount {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public Account(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
            _context = context;
        }
        public async Task<Response> Create(ApplicationUserDto registrtionData) {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == registrtionData.name);
            if (registrtionData is  not null && userInDb is null)
            {
                var user = new ApplicationUser { UserName = registrtionData.name, Email = registrtionData.email };
                var result = await _userManager.CreateAsync(user, registrtionData.password);
                if (result.Succeeded)
                    return new Response { IsSuccessed = true };
            }
            return new Response { IsSuccessed = false };
        }
    }
}
