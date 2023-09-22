using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class KnownProgramComponent : ViewComponent
    {
        private readonly ILogger<KnownProgramComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<KnownProgramEntity> _repositoryManager;

        public KnownProgramComponent(IRepositoryManager<KnownProgramEntity> repositoryManager, ILogger<KnownProgramComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var knownPrograms = _repositoryManager.Get().ToList();
            var knownProgramsDTO = _mapper.Map<List<KnownProgramDTO>>(knownPrograms);
            return View(knownProgramsDTO);
        }
    }
}
