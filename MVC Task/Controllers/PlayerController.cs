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
            var character = new CharacterViewModel();
            return View(character);
        }

        [HttpPost]
        public IActionResult CreateCharacter(CharacterViewModel character)
        {
            character.AmountOfMoney = 100;
            return RedirectToAction("MainGameplay", "Gameplay", character);
        }

        public IActionResult PlayersDeath(CharacterViewModel character)
        {
            
            var player = new Player()
            {
                AmountOfTurns = character.AmountOfTurns,
                HasWon = false,
                IsAlive = false
            };
            _unitOfWork.PlayerRepository.Add(player);
            var playerInfo = new PlayerInfo()
            {
                AmountOfMoney = character.AmountOfMoney,
                Name = character.Name,
                Race = character.Race,
                PlayerId = _unitOfWork.PlayerRepository.GetAll().Count()
            };
            _unitOfWork.PlayerInfoRepository.Add(playerInfo);
            return View(character);
        }
    }
}
