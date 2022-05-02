using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class ThievesController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ThievesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen()
        {
            return View();
        }
    }
}
