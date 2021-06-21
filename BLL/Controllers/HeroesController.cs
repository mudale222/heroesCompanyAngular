using heroesCompany.DAL.UnitOfWork;
using heroesCompany.dto;
using heroesCompany.Filters;
using heroesCompany.Models;
using heroesCompany.Models.HelperModels;
using heroesCompany.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace heroesCompany.Controllers {
    [Authorize]
    [TypeFilter(typeof(ExceptionFilter))]
    public class HeroesController : Controller {
        private readonly UnitOfWork unitOfWork;

        public HeroesController(UnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Bind] HeroDto heroData) {

            if (ModelState.IsValid) {
                var hero = await unitOfWork.HeroRepo.Create(heroData, User);
                await unitOfWork.SaveAsync();
                return Ok(new Response { IsSuccessed = true, Data = hero });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                  new Response { IsSuccessed = false, Error = new Error(400, "Hero data invalid!") });
        }


        [HttpPost]
        public ObjectResult GetHeroes() {
            var orderdHeroes = unitOfWork.HeroRepo.GetAll4User(User);
            return Ok(new Response { IsSuccessed = true, Data = orderdHeroes });
        }


        [HttpPatch]
        [TypeFilter(typeof(ActionFilter))]
        public async Task<IActionResult> Train([FromBody][Bind] CardId cardIdClass) {
            var hero = await unitOfWork.HeroRepo.Train(cardIdClass);
            await unitOfWork.SaveAsync();
            return Ok(new Response {
                IsSuccessed = true,
                Data = new PowerUpdateResponse() {
                    isTrainSuccess = true,
                    updatedPower = hero.CurrentPower
                }
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody][Bind] CardId cardIdClass) {
            var removedHero = await unitOfWork.HeroRepo.Remove(cardIdClass, User);
            if (removedHero is not null) {
                await unitOfWork.SaveAsync();
                return Ok(new Response { IsSuccessed = true, Data = removedHero });
            }
            return StatusCode(403, new Response { IsSuccessed = false, Error = new Error(403, "No hero to remove!") });
        }

        public ObjectResult Error() {
            return StatusCode(500, new Response { IsSuccessed = false, Error = new Error(500, "internal error") });
        }
    }
}
