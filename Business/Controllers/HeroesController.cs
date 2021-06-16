using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using heroesCompanyAngular.Data;
using heroesCompanyAngular.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using heroesCompanyAngular.dto;
using heroesCompanyAngular.Models.HelperModels;
using heroesCompanyAngular.Models.ResponseModels;
using heroesCompanyAngular.filters;
using heroesCompanyAngular.Filters;

namespace heroesCompanyAngular.Controllers {
    [Authorize]
    [TypeFilter(typeof(ExceptionFilter))]
    public class HeroesController : Controller {
        private readonly HeroRepository _heroRepo;

        public HeroesController(HeroRepository heroRepo) {
            _heroRepo = heroRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Bind] HeroDto heroData) {

            if (ModelState.IsValid) {
                var hero = await _heroRepo.Create(heroData, User);
                return Ok(new Response { IsSuccessed = true, Data = hero });
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                  new Response { IsSuccessed = false, Error = new Error(400, "Hero data invalid!") });
        }


        [HttpPost]
        public ObjectResult GetHeroes() {
            var orderdHeroes = _heroRepo.GetAll4User(User);
            return Ok(new Response { IsSuccessed = true, Data = orderdHeroes });
        }


        [HttpPatch]
        [TypeFilter(typeof(ActionFilter))]
        public async Task<IActionResult> Train([FromBody][Bind] CardId cardIdClass) {
            var hero = await _heroRepo.Train(cardIdClass);
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
            var removedHero = await _heroRepo.Remove(cardIdClass, User);
            if (removedHero is not null)
                return Ok(new Response { IsSuccessed = true, Data = removedHero });
            return StatusCode(403, new Response { IsSuccessed = false, Error = new Error(403, "No hero to remove!") });
        }

        public ObjectResult Error() {
            return StatusCode(500, new Response { IsSuccessed = false, Error = new Error(500, "internal error") });
        }
    }
}
