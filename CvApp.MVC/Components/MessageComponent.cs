using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class MessageComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MessageComponent> _logger;
        private readonly IRepositoryManager<MessageEntity> _repositoryManager;

        public MessageComponent(IRepositoryManager<MessageEntity> repositoryManager, ILogger<MessageComponent> logger = null, IMapper mapper = null)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
