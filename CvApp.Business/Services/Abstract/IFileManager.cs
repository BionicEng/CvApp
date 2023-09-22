using CvApp.Business.Services.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Business.Services.Abstract
{
    public interface IFileManager
    {
        List<string> GetFiles();
        Task<UploadResponse> UploadFileAsync(IFormFile formFile);
        Task<DownloadResponse?> DownloadFileAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}

