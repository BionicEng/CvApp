using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class JobInformationComponent : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
