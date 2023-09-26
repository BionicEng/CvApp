using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using CvApp.Models.DTO.CvApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class ReferanceComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ReferanceComponent> _logger;
        private readonly IRepositoryManager<ReferanceEntity> _repositoryManager;

        public ReferanceComponent(IMapper mapper, ILogger<ReferanceComponent> logger, IRepositoryManager<ReferanceEntity> repositoryManager)
        {
            _mapper = mapper;
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        public IViewComponentResult Invoke()
        {
            var referances = _repositoryManager.Get().ToList();
            var ReferanceDTO = _mapper.Map<List<ReferanceDTO>>(referances);
            return View(ReferanceDTO);
        }
    }
}
