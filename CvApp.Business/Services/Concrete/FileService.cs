using CvApp.Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Business.Services.Concrete
{
    public class FileService : IFileManager
    {
        private readonly ILogger<FileService> _logger;
        private readonly string _rootPath;

        public FileService(IConfiguration configuration, IHostingEnvironment _environment, ILogger<FileService> logger)
        {
            Configuration = configuration;
            _rootPath = Path.Combine(_environment.ContentRootPath, "wwwroot");
            _logger = logger;
        }

        private IConfiguration Configuration { get; }

        public async Task DeleteAsync(string fileName)
        {
            await Task.Run(() =>
            {
                var uploadFolder = GetUploadFolder();
                var fullFilePath = Path.Combine(uploadFolder, fileName);
                if (System.IO.File.Exists(fullFilePath))
                {
                    System.IO.File.Delete(fullFilePath);
                    _logger.LogInformation($"Upload:{fileName} ok");
                }
            });
        }

        public async Task<DownloadResponse?> DownloadFileAsync(string fileName)
        {
            var downloadFolder = GetUploadFolder();
            var fullFilePath = Path.Combine(downloadFolder, fileName);
            if (!System.IO.File.Exists(fullFilePath))
            {
                return null;
            }
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fullFilePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            _logger.LogInformation($"Download:{fileName} ok");
            return new DownloadResponse
            {
                FileName = fileName,
                ContentType = contentType,
                FileContent = await System.IO.File.ReadAllBytesAsync(fullFilePath)

            };
        }

        public List<string> GetFiles()
        {
            var uploadFolder = GetUploadFolder();

            var files = Directory.GetFiles(uploadFolder);
            _logger.LogInformation($"Get:{files} ok");
            return files.Select(f => Path.GetFileName(f)).ToList();
        }

        public async Task<UploadResponse> UploadFileAsync(IFormFile formFile)
        {
            var uploadFolder = GetUploadFolder();

            var fullFilePath = Path.Combine(uploadFolder, formFile.FileName);

            using var fileStream = new FileStream(fullFilePath, FileMode.Create);

            await formFile.CopyToAsync(fileStream);
            _logger.LogInformation($"Upload:{formFile.FileName} ok");
            return new UploadResponse 
            {
                FileName= formFile.FileName,
                FilePath = fullFilePath,
                
            };

        }

        private string GetUploadFolder()
        {
            var localUploadFolder = Configuration.GetSection("FileUploadLocation").Value;
            if (string.IsNullOrWhiteSpace(localUploadFolder))
            {
                throw new InvalidOperationException("FileUploadLocation is not configured.");
            }
            var fullPath = Path.Combine(_rootPath, localUploadFolder);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }
        private string GetDownloadFolder()
        {
            var localDownloadFolder = Configuration.GetSection("FileDownloadLocation").Value;
            if (string.IsNullOrWhiteSpace(localDownloadFolder))
            {
                throw new InvalidOperationException("FileDownloadLocation is not configured.");
            }
            var fullPath = Path.Combine(_rootPath, localDownloadFolder);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }
    }
}
