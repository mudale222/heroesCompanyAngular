using heroesCompany.DAL.UnitOfWork;
using heroesCompany.dto;
using heroesCompany.Filters;
using heroesCompany.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace heroesCompany.Controllers {
    [TypeFilter(typeof(ExceptionFilter))]
    public class AccountController : Controller {
        private readonly UnitOfWork unitOfWork;

        public AccountController(UnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationUserDto registrtionData) {
            var regResult = await unitOfWork.Account.Create(registrtionData);
            if (regResult.IsSuccessed)
                return Ok(new Response { IsSuccessed = true });
            return StatusCode(StatusCodes.Status400BadRequest,
                new Response {
                    IsSuccessed = false,
                    Error = new Error(400, "Registrtion data invalid! Probably username or email already taken!")
                });
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ApplicationUserLoginDto loginData) {
            if (loginData is not null) {
                var result = await unitOfWork.Account.signManager.PasswordSignInAsync(loginData.userName, loginData.password, false, false);
                if (result.Succeeded)
                    return Ok(new Response { IsSuccessed = true });
                return Unauthorized(new Response { IsSuccessed = false, Error = new Error(401, "Login fail! check your password and user name!") });
            }
            return StatusCode(StatusCodes.Status403Forbidden,
                   new Response { IsSuccessed = false, Error = new Error(403, "Login data invalid!") });
        }

        [HttpPost]
        public async Task<IActionResult> Logout() {
            await unitOfWork.Account.signManager.SignOutAsync();
            return Ok(new Response { IsSuccessed = true });
        }
    }
}
