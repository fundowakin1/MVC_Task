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
        public IActionResult WhenChosen(CharacterViewModel character)
        {
            var foolsGuild = _unitOfWork.GuildRepository.GetOneByName("The Guild of Fools and Joculators and College of Clowns").Members.ToList();
            var random = new Random();
            var chosenMemberId = random.Next(0, foolsGuild.Count);
            var fool = foolsGuild[chosenMemberId];
            character.AmountOfMoneyToInteract = fool.MemberInfoEntity.AmountOfMoney;
            var guidAndCharacterInfo = new FoolViewModel() { Fool = fool, Character = character };
            return View(guidAndCharacterInfo);
        }

        public IActionResult InteractionWithFool(CharacterViewModel character)
        {
            character.AmountOfTurns++;
            character.AmountOfMoney += character.AmountOfMoneyToInteract;
            return RedirectToAction("MainGameplay", "Gameplay", character);
        }
    }
}
