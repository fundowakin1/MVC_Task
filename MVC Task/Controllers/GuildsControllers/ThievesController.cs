using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class ThievesController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ThievesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen()
        {
            if (CharacterViewModel.MetThieves<=0)
            {
                return RedirectToAction("MainGameplay", "Gameplay");
            }
            var thievesGuild = _unitOfWork.GuildRepository.GetOneByName("Guild of Thieves, Cutpurses and Allied Trades").Members.ToList();
            var random = new Random();
            var chosenMemberId = random.Next(0, thievesGuild.Count);
            var thieve = thievesGuild[chosenMemberId];
            CharacterViewModel.MetThieves--;
            CharacterViewModel.AmountOfMoneyToInteract = thieve.MemberInfoEntity.AmountOfMoney;
            var guidInfo = new ThiefViewModel() { Thief = thieve};
            return View(guidInfo);
        }
        
        public IActionResult InteractionWithThief()
        {
            CharacterViewModel.AmountOfTurns++;
            CharacterViewModel.NpcMet = "Thief";
            CharacterViewModel.AmountOfMoney -= CharacterViewModel.AmountOfMoneyToInteract;
            if (CharacterViewModel.NumberOfRetries > 0 && CharacterViewModel.AmountOfMoney > 0)
                return RedirectToAction("EndOfTurn", "Pub");
            CharacterViewModel.HasWon = false;
            CharacterViewModel.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player");
        }


    }
}
