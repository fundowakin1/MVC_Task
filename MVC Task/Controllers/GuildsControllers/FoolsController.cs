using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class FoolsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public FoolsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen()
        {
            return View();
        }
    }
}
