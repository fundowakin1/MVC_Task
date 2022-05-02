using Microsoft.AspNetCore.Mvc;
using MVC_Task.UOW;

namespace MVC_Task.Controllers.GuildsControllers
{
    public class BeggarsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public BeggarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult WhenChosen()
        {
            return View();
        }
    }
}
