using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    public class MessageController : Controller
    {
        private readonly IRepositoryManager<MessageEntity> _repositoryManager;
        private readonly ILogger<MessageController> _logger;
        private readonly IMapper _mapper;

        public MessageController(IRepositoryManager<MessageEntity> repositoryManager, ILogger<MessageController> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult List()
        {
            var messages = _repositoryManager.Get().ToList();
            var messagesDTO = _mapper.Map<List<MessageDTO>>(messages);
            return View(messagesDTO);
        }
        [HttpPost]
        public IActionResult Create([FromForm] MessageDTO messageDTO)
            {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurunuz!";
                return RedirectToAction("Index", "Home");
            };
            var messageEntity = _mapper.Map<MessageEntity>(messageDTO);
            var result = _repositoryManager.Add(messageEntity);

            return RedirectToAction("Index","Home");

        }
        [HttpGet]
        public IActionResult Create()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)    
        {
            var result = _repositoryManager.GetById(id);
            if (result.Data is null)
            {
                ViewBag.ErrorMessage = "Mesaj bulunamadı.";
                return View();
            }
            _repositoryManager.DeleteAsync(result.Data);
            return RedirectToAction("List","Message");
            

            
        }
    }
}
