using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers
{
    public class GameplayController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public GameplayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult MainGameplay()
        {
            var numberOfGuilds = _unitOfWork.GuildRepository.GetAll().Count();
            var r = new Random();
            var chosenGuild = r.Next(0, numberOfGuilds);
            return chosenGuild switch
            {
                0 => RedirectToAction("WhenChosen", "Assassins"),
                1 => RedirectToAction("WhenChosen", "Thieves"),
                2 => RedirectToAction("WhenChosen", "Beggars"),
                3 => RedirectToAction("WhenChosen", "Fools"),
                _ => View()
            };
        }
    }
}
