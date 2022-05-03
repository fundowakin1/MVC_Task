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
        public IActionResult WhenChosen(CharacterViewModel character)
        {
            if (character.MetThieves<=0)
            {
                return RedirectToAction("MainGameplay", "Gameplay", character);
            }
            var thievesGuild = _unitOfWork.GuildRepository.GetOneByName("Guild of Thieves, Cutpurses and Allied Trades").Members.ToList();
            var random = new Random();
            var chosenMemberId = random.Next(0, thievesGuild.Count);
            var thieve = thievesGuild[chosenMemberId];
            character.MetThieves--;
            var guidAndCharacterInfo = new ThiefViewModel() { Thief = thieve, Character = character };
            return View(guidAndCharacterInfo);
        }
        
        public IActionResult InteractionWithThief(ThiefViewModel guidAndCharacterInfo)
        {
            var character = guidAndCharacterInfo.Character;
            character.AmountOfTurns++;
            var thief = guidAndCharacterInfo.Thief;
            var money = character.AmountOfMoney -= thief.MemberInfoEntity.AmountOfMoney;
            if (character.NumberOfRetries > 0 && money > 0)
                return RedirectToAction("MainGameplay", "Gameplay", character);
            character.HasWon = false;
            character.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player", character);
        }


    }
}
