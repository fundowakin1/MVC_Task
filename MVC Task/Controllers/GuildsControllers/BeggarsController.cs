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
        public IActionResult WhenChosen()
        {
            var beggarsGuild = _unitOfWork.GuildRepository.GetOneByName("Ankh-Morpork Beggars' Guild").Members.ToList();
            var random = new Random();
            var chosenMemberId = random.Next(0, beggarsGuild.Count);
            var beggar = beggarsGuild[chosenMemberId];
            CharacterViewModel.AmountOfMoneyToInteract = beggar.MemberInfoEntity.AmountOfMoney;
            var guidInfo = new BeggarViewModel() {Beggar = beggar};
            return View(guidInfo);
        }
        public IActionResult InteractionWithBeggar()
        {
            CharacterViewModel.AmountOfTurns++;

            CharacterViewModel.AmountOfMoney -= CharacterViewModel.AmountOfMoneyToInteract;

            if (CharacterViewModel.NumberOfRetries > 0 && CharacterViewModel.AmountOfMoney > 0)
                return RedirectToAction("EndOfTurn", "Pub");
            CharacterViewModel.HasWon = false;
            CharacterViewModel.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player");
        }
        public IActionResult InteractionWithAlcoholic()
        {
            CharacterViewModel.AmountOfTurns++;
            if (CharacterViewModel.PintsOfBeer>0)
            {
                CharacterViewModel.PintsOfBeer--;
                return RedirectToAction("EndOfTurn", "Pub");
            }

            CharacterViewModel.HasWon = false;
            CharacterViewModel.IsAlive = false;
            return RedirectToAction("PlayersDeath", "Player");
        }

        
    }
}
