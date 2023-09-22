using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using CvApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CvApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryManager<UserEntity> _userRepository;
        private readonly IRepositoryManager<PersonEntity> _personRepository;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, IRepositoryManager<UserEntity> userRepository, IMapper mapper, IRepositoryManager<PersonEntity> personRepository = null)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}