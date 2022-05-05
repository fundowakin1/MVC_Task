using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class FoolsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public FoolsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen()
        {
            var foolsGuild = _unitOfWork.GuildRepository.GetOneByName("The Guild of Fools and Joculators and College of Clowns").Members.ToList();
            var random = new Random();
            var chosenMemberId = random.Next(0, foolsGuild.Count);
            var fool = foolsGuild[chosenMemberId];
            CharacterViewModel.AmountOfMoneyToInteract = fool.MemberInfoEntity.AmountOfMoney;
            var guidInfo = new FoolViewModel() { Fool = fool};
            return View(guidInfo);
        }

        public IActionResult InteractionWithFool()
        {
            CharacterViewModel.AmountOfTurns++;
            CharacterViewModel.AmountOfMoney += CharacterViewModel.AmountOfMoneyToInteract;
            return RedirectToAction("EndOfTurn", "Pub");
        }
    }
}
