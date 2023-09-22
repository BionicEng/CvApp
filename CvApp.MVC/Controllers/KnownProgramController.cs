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
    [Authorize]
    public class KnownProgramController : Controller
    {
        private readonly ILogger<KnownProgramController> _logger;
        private readonly IRepositoryManager<KnownProgramEntity> _knownRepo;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public KnownProgramController(IFileManager fileManager, IMapper mapper, IRepositoryManager<KnownProgramEntity> knownRepo, ILogger<KnownProgramController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _knownRepo = knownRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var knownPrograms = _knownRepo.Get().ToList();
            if (knownPrograms == null)
            {
                return NotFound();

            }

            var knownDTO = _mapper.Map<List<KnownProgramDTO>>(knownPrograms);
            return View(knownDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] KnownProgramDTO knownProgram, [FromForm] IFormFile? formFile)
        {
            if (knownProgram == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return BadRequest(ModelState);

            }
            var knownProgramEntity = _mapper.Map<KnownProgramEntity>(knownProgram);
            if (formFile != null)
            {
                var uploadResponse = await _fileManager.UploadFileAsync(formFile);
                knownProgramEntity.fileName = uploadResponse.FileName;
                knownProgramEntity.filePath = uploadResponse.FilePath;

            }
                
            
            var result = _knownRepo.Add(knownProgramEntity);
            ViewBag.SuccessMessage = "Program bilgisi başarılı şekilde eklendi.";
            _logger.LogInformation("Program bilgisi başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var knownProgram = _knownRepo.GetById(id).Data;
            var knowmProgramDTO = _mapper.Map<KnownProgramDTO>(knownProgram);
            return View(knowmProgramDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] KnownProgramDTO knownProgram, [FromForm] IFormFile formFile)
        {
            var entity = _knownRepo.GetById(id).Data;
            entity.ProgramName = knownProgram.ProgramName;
            entity.ProgramDescription = knownProgram.ProgramDescription;

            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _knownRepo.Update(entity);
            return RedirectToAction(nameof(List));


        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _knownRepo.GetById(id);
            _knownRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _knownRepo.GetById(id);
            var knownProgram = _mapper.Map<KnownProgramDTO>(result.Data);
            return View(knownProgram);
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
