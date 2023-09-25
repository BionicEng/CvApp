using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class HeroComponent : ViewComponent
    {
        private readonly ILogger<HeroComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<UserEntity> _repositoryManager;

        public HeroComponent(IRepositoryManager<UserEntity> repositoryManager, ILogger<HeroComponent> logger, IMapper mapper)
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
