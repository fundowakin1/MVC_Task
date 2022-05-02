using Microsoft.AspNetCore.Mvc;

namespace MVC_Task.Controllers
{
    public class GameplayController : Controller
    {
        
        public IActionResult MainGameplay()
        {
            return View();
        }
    }
}
