using Microsoft.AspNetCore.Mvc;

namespace Task_manager.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
