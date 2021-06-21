using heroesCompanyAngular.ControllersServices;
using heroesCompanyAngular.DAL.UnitOfWork;
using heroesCompanyAngular.Data;
using heroesCompanyAngular.dto;
using heroesCompanyAngular.filters;
using heroesCompanyAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.Controllers {
    [TypeFilter(typeof(ExceptionFilter))]
    public class AccountController : Controller {
        private readonly UnitOfWork _unitOfWork;

        public AccountController(UnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationUserDto registrtionData) {
            //var regResult = await _account.Create(registrtionData);
            var regResult = await _unitOfWork.Account.Create(registrtionData);
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
                var result = await _unitOfWork.Account.signManager.PasswordSignInAsync(loginData.userName, loginData.password, false, false);
                if (result.Succeeded)
                    return Ok(new Response { IsSuccessed = true });
                return Unauthorized(new Response { IsSuccessed = false, Error = new Error(401, "Login fail! check your password and user name!") });
            }
            return StatusCode(StatusCodes.Status403Forbidden,
                   new Response { IsSuccessed = false, Error = new Error(403, "Login data invalid!") });
        }

        [HttpPost]
        public async Task<IActionResult> Logout() {
            await _unitOfWork.Account.signManager.SignOutAsync();
            return Ok(new Response { IsSuccessed = true });
        }
    }
}
