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
    public class EducationController : Controller
    {
        private readonly ILogger<EducationController> _logger;
        private readonly IRepositoryManager<EducationEntity> _educationRepo;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public EducationController(IFileManager fileManager, IMapper mapper, IRepositoryManager<EducationEntity> educationRepo, ILogger<EducationController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _educationRepo = educationRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var educations = _educationRepo.Get().ToList();
            if (educations == null)
            {
                return NotFound();

            }

            var educationDTO = _mapper.Map<List<EducationDTO>>(educations);
            return View(educationDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] EducationDTO education, [FromForm] IFormFile formFile)
        {
            if (education == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return View();

            }
            var educationEnt = _mapper.Map<EducationEntity>(education);
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            educationEnt.fileName = uploadResponse.FileName;
            educationEnt.filePath = uploadResponse.FilePath;
            var result = _educationRepo.Add(educationEnt);
            ViewBag.SuccessMessage = "Eğitim bilgisi başarılı şekilde eklendi.";
            _logger.LogInformation("Eğitim bilgisi başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var education = _educationRepo.GetById(id).Data;
            var EducationDTO = _mapper.Map<EducationDTO>(education);
            return View(EducationDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] EducationDTO education, [FromForm] IFormFile formFile)
        {
            var entity = _educationRepo.GetById(id).Data;
            entity.UniversityName = education.UniversityName;
            entity.FacultyName = education.FacultyName;
            entity.Department = education.Department;
            entity.EducationDescription = education.EducationDescription;
            entity.EducationType = education.EducationType;
            entity.EducationLanguage = education.EducationLanguage;
            entity.DegreeNote = education.DegreeNote;
            entity.StartedTime = education.StartedTime;
            entity.EndTime = education.EndTime;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _educationRepo.Update(entity);
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
            var result = _educationRepo.GetById(id);
            _educationRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _educationRepo.GetById(id);
            var educationDTO = _mapper.Map<EducationDTO>(result.Data);
            return View(educationDTO);
        }

    }
}
