using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class ContactComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<UserEntity> _repositoryManager;
        private readonly ILogger<ContactComponent> _logger;

        public ContactComponent(IMapper mapper, IRepositoryManager<UserEntity> repositoryManager, ILogger<ContactComponent> logger = null)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            var user = _repositoryManager.Get().FirstOrDefault();
            var userDTO = _mapper.Map<UserDTO>(user);
            return View(userDTO);
        }
    }
}
