using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.Models;
using MVC_Task.UOW;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class BeggarsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public BeggarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen(CharacterViewModel character)
        {
            var beggarsGuild = _unitOfWork.GuildRepository.GetOneByName("Ankh-Morpork Beggars' Guild").Members.ToList();
            var random = new Random();
            var chosenMemberId = random.Next(0, beggarsGuild.Count);
            var beggar = beggarsGuild[chosenMemberId];
            var guidAndCharacterInfo = new BeggarViewModel(){Beggar = beggar, Character = character};
            return View(guidAndCharacterInfo);
        }
        public IActionResult InteractionWithBeggar(CharacterViewModel character, Member member, MemberInfo memberInfo)
        {
            var _character = character;
            character.AmountOfTurns++;
            var beggar = member;
            var money = character.AmountOfMoney -= memberInfo.AmountOfMoney;

            if (character.NumberOfRetries > 0 && money > 0)
                return RedirectToAction("MainGameplay", "Gameplay", _character);
            _character.HasWon = false;
            _character.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player", _character);
        }
    }
}
