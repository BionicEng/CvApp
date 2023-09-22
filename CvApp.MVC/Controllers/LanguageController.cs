using AutoMapper;
using CvApp.Business.Services.Abstract;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    [Authorize]
    public class LanguageController : Controller
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly IRepositoryManager<LanguageEntity> _languageRepo;

        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public LanguageController(IFileManager fileManager, IMapper mapper, IRepositoryManager<LanguageEntity> languageRepo, ILogger<LanguageController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _languageRepo = languageRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var languages = _languageRepo.Get().ToList();
            if (languages == null)
            {
                return NotFound();

            }

            var languagesDTO = _mapper.Map<List<LanguageDTO>>(languages);
            return View(languagesDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] LanguageDTO languageDTO, [FromForm] IFormFile formFile)
        {
            if (languageDTO == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return BadRequest(ModelState);

            }
            var LanguageInfoCount = _languageRepo.Get().Count();
            var LanguageEnt = _mapper.Map<LanguageEntity>(languageDTO);
            LanguageEnt.LanguageCount = LanguageInfoCount + 1;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            LanguageEnt.fileName = uploadResponse.FileName;
            LanguageEnt.filePath = uploadResponse.FilePath;
            var result = _languageRepo.Add(LanguageEnt);
            ViewBag.SuccessMessage = "Dil bilgisi başarılı şekilde eklendi.";
            _logger.LogInformation("Dil bilgisi başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var language = _languageRepo.GetById(id).Data;
            var languageDTO = _mapper.Map<LanguageDTO>(language);
            return View(languageDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] LanguageDTO languageDTO, [FromForm] IFormFile formFile)
        {
            var entity = _languageRepo.GetById(id).Data;
            entity.LanguageName = languageDTO.LanguageName;
            entity.LanguageDescription = languageDTO.LanguageDescription;
            entity.LanguageLevel = languageDTO.LanguageLevel;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _languageRepo.Update(entity);
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
            var result = _languageRepo.GetById(id);
            _languageRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _languageRepo.GetById(id);
            var jobInformationDTO = _mapper.Map<LanguageDTO>(result.Data);
            return View(jobInformationDTO);
        }

    }
}
