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
    public class JobInformationController : Controller
    {
        private readonly ILogger<JobInformationController> _logger;
        private readonly IRepositoryManager<JobInformationEntity> _jobInformationRepo;

        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public JobInformationController(IFileManager fileManager, IMapper mapper, IRepositoryManager<JobInformationEntity> jobInRepo, ILogger<JobInformationController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _jobInformationRepo = jobInRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var jobInformation = _jobInformationRepo.Get().ToList();
            if (jobInformation == null)
            {
                return NotFound();

            }

            var jobInformationDTO = _mapper.Map<List<JobInformationDTO>>(jobInformation);
            return View(jobInformationDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] JobInformationDTO jobInformation, [FromForm] IFormFile? formFile)
        {
            if (jobInformation == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return BadRequest(ModelState);

            }
            var JobInfoCount = _jobInformationRepo.Get().Count();
            var jobInformationEnt = _mapper.Map<JobInformationEntity>(jobInformation);
            jobInformationEnt.CompanyId = JobInfoCount+1;

            if (formFile != null)
            {
                var uploadResponse = await _fileManager.UploadFileAsync(formFile);
                jobInformationEnt.fileName = uploadResponse.FileName;
                jobInformationEnt.filePath = uploadResponse.FilePath;

            }
            
            var result = _jobInformationRepo.Add(jobInformationEnt);
            ViewBag.SuccessMessage = "Eğitim bilgisi başarılı şekilde eklendi.";
            _logger.LogInformation("Eğitim bilgisi başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var jobInformation = _jobInformationRepo.GetById(id).Data;
            var jobInformationDTO = _mapper.Map<JobInformationDTO>(jobInformation);
            return View(jobInformationDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] JobInformationDTO jobInformation, [FromForm] IFormFile formFile)
        {
            var entity = _jobInformationRepo.GetById(id).Data;
            entity.JobTitle = jobInformation.JobTitle;
            entity.JobDescription = jobInformation.JobDescription;
            entity.IsContinue = jobInformation.IsContinue;
            entity.WorkingMethod = jobInformation.WorkingMethod;
            entity.fileName = jobInformation.fileName;
            entity.StartedTime = jobInformation.StartedTime;
            entity.EndTime = jobInformation.EndTime;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _jobInformationRepo.Update(entity);
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
            var result = _jobInformationRepo.GetById(id);
            _jobInformationRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _jobInformationRepo.GetById(id);
            var jobInformationDTO = _mapper.Map<JobInformationDTO>(result.Data);
            return View(jobInformationDTO);
        }

    }
}
