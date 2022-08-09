using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Thanh_An_Group.Controllers
{
    public class UploandImagesController : Controller
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public IActionResult Index()
        {
            return View();
        }
        public UploandImagesController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
      
        public async Task<JsonResult> OnPostUploadImage([FromForm] IFormFile upload)
        {
            if (upload.Length <= 0) return null;

           

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            //save file under wwwroot/CKEditorImages folder

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/CKEditorImages",
                fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await upload.CopyToAsync(stream);
            }

            var url = $"{"/CKEditorImages/"}{fileName}";

            var success = new uploadsuccess
            {
                Uploaded = 1,
                FileName = fileName,
                Url = url
            };

            return new JsonResult(success);
        }
    }
    public class uploadsuccess
    {
        public int Uploaded { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
