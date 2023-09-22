using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class UserComponent : ViewComponent
    {
        private readonly ILogger<UserComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<UserEntity> _repositoryManager;

        public UserComponent(IRepositoryManager<UserEntity> repositoryManager, ILogger<UserComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var User = _repositoryManager.Get().FirstOrDefault();
            var UserDTO = _mapper.Map<UserDTO>(User);
            return View(UserDTO);
        }
    }
}
