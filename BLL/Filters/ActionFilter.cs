using heroesCompanyAngular.Data;
using heroesCompanyAngular.Models;
using heroesCompanyAngular.Models.HelperModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace heroesCompanyAngular.Filters {
    public class ActionFilter : IActionFilter {
        private readonly HeroRepository _heroRepo;
        private readonly ApplicationDbContext _context;

        public ActionFilter(HeroRepository heroRepo, ApplicationDbContext context) {
            _heroRepo = heroRepo;
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            // Do something before the action executes.
            //Debug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
            var cardIdClass = (CardId)context.ActionArguments["cardIdClass"];
            var hero = _heroRepo.GetAsync(new Guid(cardIdClass.Id)).FirstOrDefault();

            if (hero is null) {
                context.Result = new NotFoundObjectResult(new Response {
                    IsSuccessed = false,
                    Error = new Error(400, "Hero data invalid!")
                });
                return;
            }

            if (!IsCanTrain(hero)) {
                context.Result = new BadRequestObjectResult(new Response {
                    IsSuccessed = false,
                    Error = new Error(406, "Can't train more then 5 time a day!!")
                });
                return;
            }

            var heroThatBelongToUser = _context.Heroes.Where(hero =>
                (hero.Id == new Guid(cardIdClass.Id) && hero.Trainer.UserName == context.HttpContext.User.Identity.Name)).ToArray();
            if (heroThatBelongToUser.Count() < 1) {
                context.Result = new BadRequestObjectResult(new Response {
                    IsSuccessed = false,
                    Error = new Error(403, "Login data invalid!")
                });
                return;
            }
        }


        public void OnActionExecuted(ActionExecutedContext context) {
            // Do something after the action executes.
            //MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }

        public bool IsCanTrain(Hero hero) {
            if (hero.TrainedDate.Day != DateTime.Now.Day)
                hero.TrainedCount = 0;
            if (hero.TrainedCount < 5)
                return true;
            return false;
        }
    }
}
