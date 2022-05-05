using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class AssassinsController : Controller 
    {
        private static Dictionary<int, AssassinViewModel.InfoAboutAssassin> _occupationDictionary;
        private IUnitOfWork _unitOfWork;
        public AssassinsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen()
        {
            var assassinsGuild = _unitOfWork.GuildRepository.GetOneByName("Ankh-Morpork Assassins' Guild").Members.ToList();
            _occupationDictionary = new Dictionary<int, AssassinViewModel.InfoAboutAssassin>();
            for (var i = 0; i < assassinsGuild.Count; i++)
            {
                var  higherBound = assassinsGuild[i].MemberInfoEntity.AmountOfMoney;
                _occupationDictionary
                    .Add(i,new AssassinViewModel.InfoAboutAssassin(false, higherBound - 10, higherBound));
            };

            var counter = 0;
            while (counter < _occupationDictionary.Count / 2)
            {
                var random = new Random();
                var assassinId = random.Next(0, _occupationDictionary.Count);
                if (_occupationDictionary[assassinId].IsOccupied) continue;
                _occupationDictionary[assassinId].IsOccupied = true;
                counter++;
            }

            return View();
        }


        [HttpGet]
        public IActionResult InteractionWithAssassin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InteractionWithAssassinPost(decimal amountOfMoneyToInteract)
        {
            CharacterViewModel.AmountOfTurns++;
            var notOccupiedAssassins =
                _occupationDictionary.Where(assassin 
                    => assassin.Value.IsOccupied == false);
            var inputtedMoney = amountOfMoneyToInteract;
            if (CharacterViewModel.NumberOfRetries<=0)
            {
                CharacterViewModel.HasWon = false;
                CharacterViewModel.IsAlive = false;
                return RedirectToAction("PlayersDeath", "Player");
            }
            if (!notOccupiedAssassins.Any(x => x.Value.LowerFeeBound < inputtedMoney
                                               && x.Value.UpperFeeBound > inputtedMoney))
            {
                CharacterViewModel.NumberOfRetries--;
                return RedirectToAction("InteractionWithAssassin", "Assassins");
            }
            CharacterViewModel.AmountOfMoney -= inputtedMoney;
            return RedirectToAction("EndOfTurn", "Pub");

        }
    }
}
