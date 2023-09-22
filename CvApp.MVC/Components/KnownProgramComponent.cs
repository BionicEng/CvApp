using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class KnownProgramComponent : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
