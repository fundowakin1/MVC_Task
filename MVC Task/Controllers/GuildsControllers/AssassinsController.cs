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
            var assassinsGuild = _unitOfWork.GuildRepository.GetOne(1).Members.ToList();
            var occupationDictionary = new Dictionary<int, AssassinsViewModel.InfoAboutAssassin>();
            for (var i = 0; i < assassinsGuild.Count; i++)
            {
                var  higherBound = assassinsGuild[i].MemberInfoEntity.AmountOfMoney;
                occupationDictionary
                    .Add(i,new AssassinsViewModel.InfoAboutAssassin(true, higherBound - 10, higherBound));
            };

            var counter = 0;
            while (counter < occupationDictionary.Count / 2)
            {
                var random = new Random();
                var assassinId = random.Next(1, occupationDictionary.Count);
                if (!occupationDictionary[assassinId].IsOccupied) continue;
                occupationDictionary[assassinId].IsOccupied = false;
                counter++;
            }

            var guidAndCharacterInfo = new AssassinsViewModel()
            {
                Character = character,
                OccupationDictionary = occupationDictionary
            };
            return View(guidAndCharacterInfo);
        }


        [HttpGet]
        public IActionResult InteractionWithAssassin(AssassinsViewModel guidAndCharacterInfo)
        {
            var newGuildAndCharacterInfo = guidAndCharacterInfo;
            return View(newGuildAndCharacterInfo);
        }
        [HttpPost]
        public IActionResult InteractionWithAssassinPost(AssassinsViewModel guidAndCharacterInfo)
        {
            var character = guidAndCharacterInfo.Character;
            character.AmountOfMoney -= guidAndCharacterInfo.InputtedAmountOfMoney;
            character.AmountOfTurns++;
            return RedirectToAction("MainGameplay","Gameplay", character);
        }
    }
}
