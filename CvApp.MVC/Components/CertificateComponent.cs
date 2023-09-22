using AutoMapper;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO.CvApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Components
{
    public class CertificateComponent : ViewComponent
    {
        private readonly IRepositoryManager<CertificateEntity> _repositoryManager;
        private readonly IMapper _mapper;

        public CertificateComponent(IRepositoryManager<CertificateEntity> repositoryManager, IMapper mapper = null)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var certificates = _repositoryManager.Get().ToList();
            var certificatesDTO = _mapper.Map<List<CertificateDTO>>(certificates);
            return View(certificatesDTO);
        }
    }
}
