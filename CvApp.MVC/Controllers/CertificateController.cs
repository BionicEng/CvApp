using AutoMapper;
using CvApp.Business.Services.Abstract;
using CvApp.Business.Services.Concrete;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using CvApp.Models.DTO.CvApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly ILogger<CertificateController> _logger;
        private readonly IRepositoryManager<CertificateEntity> _certificateRepo;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public CertificateController(IFileManager fileManager, IMapper mapper, IRepositoryManager<CertificateEntity> certificateRepo, ILogger<CertificateController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _certificateRepo = certificateRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var certificates = _certificateRepo.Get().ToList();
            if (certificates == null)
            {
                return NotFound();

            }

            var certificatesDTO = _mapper.Map<List<CertificateDTO>>(certificates);
            return View(certificatesDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CertificateDTO certificate, [FromForm] IFormFile formFile)
        {
            if (certificate == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return View();

            }
            var certificateEnt = _mapper.Map<CertificateEntity>(certificate);
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            certificateEnt.fileName = uploadResponse.FileName;
            certificateEnt.filePath = uploadResponse.FilePath;
            var result = _certificateRepo.Add(certificateEnt);
            ViewBag.SuccessMessage = "Sertifika başarılı şekilde eklendi.";
            _logger.LogInformation("Sertifika başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var certificate = _certificateRepo.GetById(id).Data;
            var certDTO = _mapper.Map<CertificateDTO>(certificate);
            return View(certDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] CertificateDTO certificate, [FromForm] IFormFile formFile)
        {
            var entity = _certificateRepo.GetById(id).Data;
            entity.CertificateCompany = certificate.CertificateCompany;
            entity.CertificateDescription = certificate.CertificateDescription;
            entity.CertificateDate = certificate.CertificateDate;
            entity.CertificateName = certificate.CertificateName;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _certificateRepo.Update(entity);
            return RedirectToAction(nameof(List));


        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _certificateRepo.GetById(id);
            _certificateRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _certificateRepo.GetById(id);
            var certificateDTO = _mapper.Map<CertificateDTO>(result.Data);
            return View(certificateDTO);
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile formFile)
        {
            await _fileManager.UploadFileAsync(formFile);
            ViewBag.SuccessMessage = "Dosya başarıyla yüklendi";
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteFile([FromQuery] string fileName)
        {
            await _fileManager.DeleteAsync(fileName);
            ViewBag.SuccessMessage = "Dosya silindi.";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DownloadFile([FromQuery] string fileName)
        {
            var fileResult = await _fileManager.DownloadFileAsync(fileName);

            return File(fileResult.FileContent, fileResult.ContentType, fileResult.FileName);
        }


    }
}
