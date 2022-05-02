using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
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
            return RedirectToAction("MainGameplay", "Gameplay", character);
        }
    }
}
