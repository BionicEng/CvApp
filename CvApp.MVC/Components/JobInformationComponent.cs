using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class JobInformationComponent : ViewComponent
    {
        private readonly ILogger<JobInformationComponent> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager<JobInformationEntity> _repositoryManager;

        public JobInformationComponent(IRepositoryManager<JobInformationEntity> repositoryManager, ILogger<JobInformationComponent> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var jobInformations = _repositoryManager.Get().ToList();
            var JobInformationsDTO = _mapper.Map<List<JobInformationDTO>>(jobInformations);
            return View(JobInformationsDTO);
        }
    }
}
