using Microsoft.AspNetCore.Mvc;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers
{
    public class PubController : Controller
    {
        private const int _beerCost = 2;
        public IActionResult EndOfTurn()
        {
            return View();
        }
        
        public IActionResult BuyingBeer()
        {
            return View();
        }
        public IActionResult BoughtBeer()
        {
            CharacterViewModel.AmountOfMoney -= _beerCost;
            CharacterViewModel.PintsOfBeer++;
            return RedirectToAction("MainGameplay", "Gameplay");
        }
    }
}
