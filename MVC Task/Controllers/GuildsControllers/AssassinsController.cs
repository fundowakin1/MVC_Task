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
        private IUnitOfWork _unitOfWork;
        public AssassinsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen(CharacterViewModel character)
        {
            var assassinsGuild = _unitOfWork.GuildRepository.GetOneByName("Ankh-Morpork Assassins' Guild").Members.ToList();
            var occupationDictionary = new Dictionary<int, AssassinViewModel.InfoAboutAssassin>();
            for (var i = 0; i < assassinsGuild.Count; i++)
            {
                var  higherBound = assassinsGuild[i].MemberInfoEntity.AmountOfMoney;
                occupationDictionary
                    .Add(i,new AssassinViewModel.InfoAboutAssassin(false, higherBound - 10, higherBound));
            };

            var counter = 0;
            while (counter < occupationDictionary.Count / 2)
            {
                var random = new Random();
                var assassinId = random.Next(1, occupationDictionary.Count);
                if (!occupationDictionary[assassinId].IsOccupied) continue;
                occupationDictionary[assassinId].IsOccupied = true;
                counter++;
            }

            var guidAndCharacterInfo = new AssassinViewModel()
            {
                Character = character,
                OccupationDictionary = occupationDictionary
            };
            return View(guidAndCharacterInfo);
        }


        [HttpGet]
        public IActionResult InteractionWithAssassin(AssassinViewModel guidAndCharacterInfo)
        {
            var newGuildAndCharacterInfo = guidAndCharacterInfo;
            return View(newGuildAndCharacterInfo);
        }
        [HttpPost]
        public IActionResult InteractionWithAssassinPost(AssassinViewModel guidAndCharacterInfo)
        {
            var character = guidAndCharacterInfo.Character;
            var inputtedMoney = guidAndCharacterInfo.InputtedAmountOfMoney;
            character.AmountOfTurns++;
            var notOccupiedAssassins =
                guidAndCharacterInfo.OccupationDictionary.Where(assassin 
                    => assassin.Value.IsOccupied == false);
            
            if (character.NumberOfRetries<=0)
            {
                character.HasWon = false;
                character.IsAlive = false;
                return RedirectToAction("PlayersDeath", "Player", character);
            }
            if (!notOccupiedAssassins.Any(x => x.Value.LowerFeeBound < inputtedMoney
                                               && x.Value.UpperFeeBound > inputtedMoney))
            {
                guidAndCharacterInfo.Character.NumberOfRetries--;
                return RedirectToAction("InteractionWithAssassin", "Assassins", guidAndCharacterInfo);
            }
            character.AmountOfMoney -= inputtedMoney;
            return RedirectToAction("MainGameplay", "Gameplay", character);

        }
    }
}
