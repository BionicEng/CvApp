using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class ServiceComponent : ViewComponent
    {
        private readonly IMapper _mapper;

        private readonly IRepositoryManager<ServiceEntity> _repositoryManager;
        private readonly ILogger<ServiceComponent> _logger;

        public ServiceComponent(IMapper mapper, IRepositoryManager<ServiceEntity> repositoryManager = null, ILogger<ServiceComponent> logger = null)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            var services = _repositoryManager.Get().ToList();
            var servicesDTO = _mapper.Map<List<ServiceDTO>>(services);

            return View(servicesDTO);
        }
    }
}
