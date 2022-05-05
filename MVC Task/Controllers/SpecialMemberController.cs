using Microsoft.AspNetCore.Mvc;
using MVC_Task.ViewModels;

namespace MVC_Task.Controllers
{
    public class SpecialMemberController : Controller
    {
        public IActionResult InteractionWithVampireMember()
        {
            CharacterViewModel.SpecialNpcMet = "Vampire";
            return RedirectToAction("PlayersVictory", "Player");
        }
        public IActionResult InteractionWithMageMember()
        {
            CharacterViewModel.SpecialNpcMet = "Mage";
            return RedirectToAction("PlayersVictory", "Player");
        }
        public IActionResult InteractionWithVampireMageMember()
        {
            CharacterViewModel.SpecialNpcMet = "VampireMage";
            return RedirectToAction("PlayersDeath", "Player");
        }
    }
}
