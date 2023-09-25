using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class FooterComponent : ViewComponent
    {
        private readonly ILogger<FooterComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<UserEntity> _repositoryManager;

        public FooterComponent(IRepositoryManager<UserEntity> repositoryManager, ILogger<FooterComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var user = _repositoryManager.Get().FirstOrDefault();
            var userDTO = _mapper.Map<UserDTO>(user);
            return View(userDTO);
        }
    }
}
