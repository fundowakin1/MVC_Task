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
        public IActionResult WhenChosen(CharacterViewModel character)
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

            return View(character);
        }


        [HttpGet]
        public IActionResult InteractionWithAssassin(CharacterViewModel character)
        {
            return View(character);
        }
        [HttpPost]
        public IActionResult InteractionWithAssassinPost(CharacterViewModel character)
        {
            character.AmountOfTurns++;
            var notOccupiedAssassins =
                _occupationDictionary.Where(assassin 
                    => assassin.Value.IsOccupied == false);
            var inputtedMoney = character.AmountOfMoneyToInteract;
            if (character.NumberOfRetries<=0)
            {
                character.HasWon = false;
                character.IsAlive = false;
                return RedirectToAction("PlayersDeath", "Player", character);
            }
            if (!notOccupiedAssassins.Any(x => x.Value.LowerFeeBound < inputtedMoney
                                               && x.Value.UpperFeeBound > inputtedMoney))
            {
               character.NumberOfRetries--;
                return RedirectToAction("InteractionWithAssassin", "Assassins", character);
            }
            character.AmountOfMoney -= inputtedMoney;
            return RedirectToAction("EndOfTurn", "Pub", character);

        }
    }
}
