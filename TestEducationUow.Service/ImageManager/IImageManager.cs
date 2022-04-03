using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducationUow.Service.ImageManager
{
    public interface IImageManager
    {
        public bool CheckImageSize(IFormFile file);

        public bool CheckIsImage(string filename);

        public string GetFullPath(string imagename);

        public Task<string> UploadFileAsync(IFormFile file);

        public Task<string> ChangeFileAsync(string deletedImagename, IFormFile file);

        public bool DeleteFile(string filename);
    }
}
