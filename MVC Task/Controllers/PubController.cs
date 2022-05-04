using Microsoft.AspNetCore.Mvc;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers
{
    public class PubController : Controller
    {
        private const int _beerCost = 2;
        public IActionResult EndOfTurn(CharacterViewModel character)
        {
            return View(character);
        }
        
        public IActionResult BuyingBeer(CharacterViewModel character)
        {
            return View(character);
        }
        public IActionResult BoughtBeer(CharacterViewModel character)
        {
            character.AmountOfMoney -= _beerCost;
            character.PintsOfBeer++;
            return RedirectToAction("MainGameplay", "Gameplay", character);
        }
    }
}
