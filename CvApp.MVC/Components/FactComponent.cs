using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class FactComponent : ViewComponent
    {
        private readonly ILogger<FactComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<FactEntity> _repositoryManager;

        public FactComponent(IRepositoryManager<FactEntity> repositoryManager, ILogger<FactComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var fact = _repositoryManager.Get().ToList();
            var factDTO = _mapper.Map<List<FactDTO>>(fact);
            return View(factDTO);
        }
    }
}
