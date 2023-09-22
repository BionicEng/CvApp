using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class EducationComponent : ViewComponent
    {
        private readonly ILogger<EducationComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<EducationEntity> _repositoryManager;

        public EducationComponent(IRepositoryManager<EducationEntity> repositoryManager, ILogger<EducationComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var educations = _repositoryManager.Get().ToList();
            var educationsDTO = _mapper.Map<List<EducationDTO>>(educations);
            return View(educationsDTO);
        }
    }
}
