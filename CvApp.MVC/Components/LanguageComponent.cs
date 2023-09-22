using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class LanguageComponent : ViewComponent
    {
        private readonly ILogger<LanguageComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<LanguageEntity> _repositoryManager;

        public LanguageComponent(IRepositoryManager<LanguageEntity> repositoryManager, ILogger<LanguageComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var languages = _repositoryManager.Get().ToList();
            var languagesDTO = _mapper.Map<List<LanguageDTO>>(languages);
            return View(languagesDTO);
        }
    }
}
