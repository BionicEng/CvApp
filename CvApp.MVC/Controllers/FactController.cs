using AutoMapper;
using CvApp.Business.Services.Abstract;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{
    public class FactController : Controller
    {
        private readonly ILogger<FactController> _logger;
        private readonly IRepositoryManager<FactEntity> _factRepo;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public FactController(IFileManager fileManager, IMapper mapper, IRepositoryManager<FactEntity> factRepo, ILogger<FactController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _factRepo = factRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            var facts = _factRepo.Get().ToList();
            if (facts == null)
            {
                return NotFound();

            }

            var factDTO = _mapper.Map<List<FactDTO>>(facts);
            return View(factDTO);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] FactDTO factDTO)
        {
            if (factDTO == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return View();

            }
            var factEntity = _mapper.Map<FactEntity>(factDTO);


            var result = _factRepo.Add(factEntity);

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var fact = _factRepo.GetById(id).Data;
            var factDTO = _mapper.Map<FactDTO>(fact);
            return View(factDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] FactDTO factDTO)
        {
            var entity = _factRepo.GetById(id).Data;
            entity.PropertyName = factDTO.PropertyName;
            entity.PropertyStock = factDTO.PropertyStock;
            entity.Description = factDTO.Description;

            _factRepo.Update(entity);
            return RedirectToAction(nameof(List));


        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _factRepo.GetById(id);
            _factRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _factRepo.GetById(id);
            var factDTO = _mapper.Map<FactDTO>(result.Data);
            return View(factDTO);
        }

    }
}
