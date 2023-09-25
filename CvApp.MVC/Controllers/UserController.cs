using AutoMapper;
using CvApp.Business.Services.Abstract;
using CvApp.Business.Services.Concrete;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvApp.MVC.Controllers
{

    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepositoryManager<UserEntity> _userRepo;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        public UserController(IFileManager fileManager, IMapper mapper, IRepositoryManager<UserEntity> userRepo, ILogger<UserController> logger)
        {
            _fileManager = fileManager;
            _mapper = mapper;
            _userRepo = userRepo;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult List()
        {
            if(User.Identity.IsAuthenticated)
            {
                var users = _userRepo.Get().ToList();
                if (users == null)
                {
                    return NotFound();

                }

                var userDTO = _mapper.Map<List<UserDTO>>(users);
                return View(userDTO);

            }
            return RedirectToAction("Index","Home");
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserDTO userDTO, [FromForm] IFormFile formFile)
        {
            var UserCount = _userRepo.Get().Count();

            if (userDTO == null)
            {
                ViewBag.ErrorMessage = "Lütfen form boş!.";
                return View();

            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen formu eksiksiz şekilde doldurun!.";
                return BadRequest(ModelState);

            }
            var usersCount = _userRepo.Get().Count();
            var userEntity = _mapper.Map<UserEntity>(userDTO);
            userEntity.UserCount = usersCount + 1;
            userEntity.Roles = "User";
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            userEntity.fileName = uploadResponse.FileName;
            userEntity.filePath = uploadResponse.FilePath;
            var result = _userRepo.Add(userEntity);
            ViewBag.SuccessMessage = "Kişi bilgisi başarılı şekilde eklendi.";
            _logger.LogInformation("Kişi bilgisi başarılı şekilde eklendi.");

            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var user = _userRepo.GetById(id).Data;
            var userDTO = _mapper.Map<UserDTO>(user);
            return View(userDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UserDTO userDTO, [FromForm] IFormFile formFile)
        {
            var usersCount = _userRepo.Get().Count();
            var entity = _userRepo.GetById(id).Data;
            entity.FirstName = userDTO.FirstName;
            entity.LastName = userDTO.LastName;
            entity.Email = userDTO.Email;
            entity.Password = userDTO.Password;
            entity.CreatedAt = userDTO.CreatedAt;
            entity.UserName = userDTO.UserName;
            entity.PhoneNumber = userDTO.PhoneNumber;
            entity.UserCount = usersCount;
            entity.UserDescription = userDTO.UserDescription;
            entity.BirtDay = userDTO.BirtDay;
            entity.Location = userDTO.Location;
            entity.UK = userDTO.UK;
            entity.Gender = userDTO.Gender;
            entity.MSwasDone = userDTO.MSwasDone;
            entity.Roles = "User";
            entity.Hobies = userDTO.Hobies;
            entity.Location = userDTO.Location;
            entity.UK = userDTO.UK;
            entity.Gender = userDTO.Gender;
            entity.MSwasDone = userDTO.MSwasDone;
            entity.TwitterLink = userDTO.TwitterLink;
            entity.FacebookLink = userDTO.FacebookLink;
            entity.InstagramLınk = userDTO.InstagramLınk;
            entity.SkypeLınk = userDTO.SkypeLınk;
            entity.Adress = userDTO.Adress;
            entity.LinkedinLink = userDTO.LinkedinLink;
            var uploadResponse = await _fileManager.UploadFileAsync(formFile);
            entity.fileName = uploadResponse.FileName;
            entity.filePath = uploadResponse.FilePath;
            _userRepo.Update(entity);
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
            var result = _userRepo.GetById(id);
            _userRepo.Delete(result.Data);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {

            var result = _userRepo.GetById(id);
            var userDTO = _mapper.Map<UserDTO>(result.Data);
            return View(userDTO);
        }
    }
}
