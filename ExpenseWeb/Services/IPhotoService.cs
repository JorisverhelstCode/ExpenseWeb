using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ExpenseWeb.Services
{
    public interface IPhotoService
    {
        public void DeletePhoto(string url);
        public string UploadPhoto(IFormFile photo);
    }

    public class LocalPhotoService : IPhotoService
    {
        IWebHostEnvironment _hostingEnvironment;

        public LocalPhotoService(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public void DeletePhoto(string url)
        {
            if (url.StartsWith("/"))
            {
                url = url.Substring(1);
            }

            string pathName = Path.Combine(_hostingEnvironment.WebRootPath, url);
            System.IO.File.Delete(pathName);
        }

        public string UploadPhoto(IFormFile photo)
        {
            string uniqueFileName = Guid.NewGuid().ToString();

            return uniqueFileName;
        }
    }
}
