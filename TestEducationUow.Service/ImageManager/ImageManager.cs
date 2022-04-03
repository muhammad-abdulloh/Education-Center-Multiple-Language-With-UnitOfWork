//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Serilog;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestEducationUow.Service.ImageManager
//{
//    public class ImageManager : IImageManager
//    {
//        private readonly string _imageMainPath;
//        private readonly int _maxImageSize = 5;
//        public ImageManager(IWebHostEnvironment webHostEnvironment)
//        {
//            this._imageMainPath = webHostEnvironment.WebRootPath + "\\Images\\";
//        }

//        /*private string GetUniqueName(string filename)
//        {
//            string path = Guid.NewGuid().ToString();
//            string extension = Path.GetExtension(filename);
//            return path + "_" + extension;
//        }*/

//        public async Task<string> UploadFileAsync(IFormFile file)
//        {
//            try
//            {
//                string imagename = GetUniqueName(file.FileName);

//                string downloadedFilePath = _imageMainPath + imagename;

//                using (FileStream stream = File.Create(downloadedFilePath))
//                {
//                    await file.CopyToAsync(stream);
//                    await stream.FlushAsync();
//                }

//                return imagename;
//            }
//            catch (Exception error)
//            {
//                Log.Error(error, "File didn't downloaded");
//                return null;
//            }
//        }

//        public async Task<string> ChangeFileAsync(string deletedImagename,
//            IFormFile file)
//        {
//            DeleteFile(deletedImagename);
//            return await UploadFileAsync(file);
//        }

//        public bool DeleteFile(string filename)
//        {
//            try
//            {
//                string path = _imageMainPath + filename;
//                if (File.Exists(path)) File.Delete(path);
//                return true;
//            }
//            catch (Exception error)
//            {
//                Log.Error(error, "Image didn't delete");
//                return false;
//            }
//        }

//        public string GetFullPath(string imagename)
//        {
//            return _imageMainPath + imagename;
//        }

//        public bool CheckImageSize(IFormFile file)
//        {
//            long fileSizeMB = file.Length / 1024 / 1024;
//            if (fileSizeMB > _maxImageSize) return false;
//            else return true;
//        }

//        public bool CheckIsImage(string filename)
//        {
//            var postedFileExtension = Path.GetExtension(filename);
//            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".webp", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".tiff", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".bmp", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".heif", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".svg", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".eps", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".pdf", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".psd", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".ai", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".xcf", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".indd", StringComparison.OrdinalIgnoreCase)
//                && !string.Equals(postedFileExtension, ".raw", StringComparison.OrdinalIgnoreCase))
//            {
//                return false;
//            }
//            else return true;
//        }
//    }
//}
