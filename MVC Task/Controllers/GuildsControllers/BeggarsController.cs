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
            character.AmountOfMoneyToInteract = beggar.MemberInfoEntity.AmountOfMoney;
            var guidAndCharacterInfo = new BeggarViewModel() {Beggar = beggar, Character = character};
            return View(guidAndCharacterInfo);
        }
        public IActionResult InteractionWithBeggar(CharacterViewModel character)
        {
            character.AmountOfTurns++;
            
            
            character.AmountOfMoney -= character.AmountOfMoneyToInteract;

            if (character.NumberOfRetries > 0 && character.AmountOfMoney > 0)
                return RedirectToAction("EndOfTurn", "Pub", character);
            character.HasWon = false;
            character.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player", character);
        }
        public IActionResult InteractionWithAlcoholic(CharacterViewModel character)
        {
            character.AmountOfTurns++;
            if (character.PintsOfBeer>0)
            {
                character.PintsOfBeer--;
                return RedirectToAction("EndOfTurn", "Pub", character);
            }

            character.HasWon = false;
            character.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player", character);
        }
    }
}
