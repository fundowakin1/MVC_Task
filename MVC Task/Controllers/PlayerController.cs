using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.Models;
using MVC_Task.UOW;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers
{
    public class PlayerController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ShowScoreTable()
        {
            var players = _unitOfWork.PlayerRepository.GetAll().ToList();
            var playersInfo = _unitOfWork.PlayerInfoRepository.GetAll().ToList();
            var playerFullInfo = new PlayerFullInfoViewModel() {Players = players, PlayersInfo = playersInfo};
            return View(playerFullInfo);
        }

        [HttpGet]
        public IActionResult CreateCharacter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCharacter(CreateCharacterViewModel character)
        {
            CharacterViewModel.Race = character.Race;
            CharacterViewModel.AmountOfMoney = character.Race == "Elven" ? 150 : 100;
            CharacterViewModel.AmountOfMoneyToInteract = 0;
            CharacterViewModel.AmountOfTurns = 0;
            CharacterViewModel.PintsOfBeer = 0;
            CharacterViewModel.SpecialNpcMet = null;
            CharacterViewModel.MetThieves = 6;
            CharacterViewModel.HasWon = false;
            CharacterViewModel.IsAlive = true;
            CharacterViewModel.NumberOfRetries = 3;
            CharacterViewModel.Name = character.Name;
            return RedirectToAction("MainGameplay", "Gameplay");
        }

        public IActionResult PlayersDeath()
        {
            
            var player = new Player()
            {
                AmountOfTurns = CharacterViewModel.AmountOfTurns,
                HasWon = false,
                IsAlive = false
            };
            _unitOfWork.PlayerRepository.Add(player);
            var playerInfo = new PlayerInfo()
            {
                AmountOfMoney = CharacterViewModel.AmountOfMoney,
                Name = CharacterViewModel.Name,
                Race = CharacterViewModel.Race,
                PlayerId = _unitOfWork.PlayerRepository.GetAll().Count()
            };

            _unitOfWork.PlayerInfoRepository.Add(playerInfo);

            if (CharacterViewModel.SpecialNpcMet=="VampireMage")
            {
                return View("PlayersDeathFromVampireMage");
            }

            return View();
        }
        public IActionResult PlayersVictory()
        {
            
            var player = new Player()
            {
                AmountOfTurns = CharacterViewModel.AmountOfTurns,
                HasWon = true,
                IsAlive = true
            };
            _unitOfWork.PlayerRepository.Add(player);
            var playerInfo = new PlayerInfo()
            {
                AmountOfMoney = CharacterViewModel.AmountOfMoney,
                Name = CharacterViewModel.Name,
                Race = CharacterViewModel.Race,
                PlayerId = _unitOfWork.PlayerRepository.GetAll().Count()
            };
            _unitOfWork.PlayerInfoRepository.Add(playerInfo);
            return View();
        }
    }
}
