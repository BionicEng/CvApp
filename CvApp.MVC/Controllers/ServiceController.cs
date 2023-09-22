using AutoMapper;
using CvApp.Business.Services.Abstract;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using CvApp.Models.DTO.CvApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IRepositoryManager<ServiceEntity> _serviceRepo;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public ServiceController(IFileManager fileManager, IMapper mapper, IRepositoryManager<ServiceEntity> serviceRepo, ILogger<ServiceController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _serviceRepo = serviceRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var services = _serviceRepo.Get().ToList();
            if (services == null)
            {
                return NotFound();

            }

            var servicesDTO = _mapper.Map<List<ServiceDTO>>(services);
            return View(servicesDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ServiceDTO service, [FromForm] IFormFile? formFile)
        {
            if (service == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return View();

            }
            var serviceEnt = _mapper.Map<ServiceEntity>(service);
            if(formFile is not null)
            {
                var uploadResponse = await _fileManager.UploadFileAsync(formFile);
                serviceEnt.fileName = uploadResponse.FileName;
                serviceEnt.filePath = uploadResponse.FilePath;

            }
            
            var result = _serviceRepo.Add(serviceEnt);
            ViewBag.SuccessMessage = "Servis başarılı şekilde eklendi.";
            _logger.LogInformation("Servis başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var service = _serviceRepo.GetById(id).Data;
            var serviceDTO = _mapper.Map<ServiceDTO>(service);
            return View(serviceDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ServiceDTO serviceDTO, [FromForm] IFormFile? formFile)
        {
            var entity = _serviceRepo.GetById(id).Data;
            entity.Name = serviceDTO.Name;
            entity.Description = serviceDTO.Description;

            if (formFile is not null)
            {
                var uploadResponse = await _fileManager.UploadFileAsync(formFile);
                entity.fileName = uploadResponse.FileName;
                entity.filePath = uploadResponse.FilePath;

            }
           
            _serviceRepo.Update(entity);
            return RedirectToAction(nameof(List));


        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _serviceRepo.GetById(id);
            _serviceRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _serviceRepo.GetById(id);
            var serviceDTO = _mapper.Map<ServiceDTO>(result.Data);
            return View(serviceDTO);
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
