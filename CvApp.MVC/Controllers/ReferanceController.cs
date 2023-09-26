using AutoMapper;
using CvApp.Business.Services.Abstract;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    public class ReferanceController : Controller
    {
        private readonly IRepositoryManager<ReferanceEntity> _repositoryManager;
        private readonly ILogger<ReferanceController> _logger;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public ReferanceController(IRepositoryManager<ReferanceEntity> repositoryManager, ILogger<ReferanceController> logger, IMapper mapper, IFileManager fileManager = null)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        [HttpGet]
        public IActionResult List()
        {
            var referances = _repositoryManager.Get().ToList();
            var referanceDTO = _mapper.Map<List<ReferanceDTO>>(referances);
            return View(referanceDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ReferanceDTO referanceDTO, [FromForm] IFormFile formFile)
        {
            if (referanceDTO == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return BadRequest(ModelState);

            }
            var ReferanceEnt = _mapper.Map<ReferanceEntity>(referanceDTO);
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            ReferanceEnt.fileName = uploadResponse.FileName;
            ReferanceEnt.filePath = uploadResponse.FilePath;
            var result = _repositoryManager.Add(ReferanceEnt);
            ViewBag.SuccessMessage = "Referans başarılı şekilde eklendi.";
            _logger.LogInformation("Referans başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var referance = _repositoryManager.GetById(id).Data;
            var referanceDTO = _mapper.Map<ReferanceDTO>(referance);
            return View(referanceDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ReferanceDTO referanceDTO, [FromForm] IFormFile formFile)
        {
            var entity = _repositoryManager.GetById(id).Data;
            entity.ReferanceName = referanceDTO.ReferanceName;
            entity.ReferanceTitle = referanceDTO.ReferanceTitle;
            entity.ReferanceDescription = referanceDTO.ReferanceDescription;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _repositoryManager.Update(entity);
            return RedirectToAction(nameof(List));


        }
        public async Task<IActionResult> DownloadFile([FromQuery] string fileName)
        {
            var fileResult = await _fileManager.DownloadFileAsync(fileName);

            return File(fileResult.FileContent, fileResult.ContentType, fileResult.FileName);
        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _repositoryManager.GetById(id);
            _repositoryManager.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _repositoryManager.GetById(id);
            var referanceDTO = _mapper.Map<ReferanceDTO>(result.Data);
            return View(referanceDTO);
        }

    }
}
