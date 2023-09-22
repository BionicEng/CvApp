using CvApp.Business.Services.Abstract;
using CvApp.Business.Services.Concrete;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthManager _authManager;
        private readonly ILogger<AuthController> _logger;
        private readonly IRepositoryManager<UserEntity> _repositoryManager;
        public AuthController(IAuthManager authManager, ILogger<AuthController> logger, IRepositoryManager<UserEntity> repositoryManager = null)
        {
            _authManager = authManager;
            _logger = logger;
            _repositoryManager = repositoryManager;
        }
        [HttpPost]
        public IActionResult Login([FromForm]LoginViewModel loginModel)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }

            var token = _authManager.GenerateToken(loginModel.Email, loginModel.Password);
            if (token == null) 
            {
                ViewBag.ErrorMessage = ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
                return View();

            }
            Response.Cookies.Append("cv-app-token",token);
            
            return RedirectToAction("Index","Home");

        }

        [HttpGet]
        public IActionResult Login()
        {
           return View();
        }
        [HttpGet]
        public IActionResult Logout() 
        {
            Response.Cookies.Delete("cv-app-token");
            return RedirectToAction("Index", "Home");
        }
    }
}
