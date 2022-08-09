using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThanhAn_group.BLL.IService;
using ThanhAn_Group.DAL.Models;

namespace Thanh_An_Group.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GallImagesController : Controller
    {
        private static IGallImages_Service GallImages_Service;
        private readonly IWebHostEnvironment hostEnvironment;

        public GallImagesController(IGallImages_Service service, IWebHostEnvironment hostEnvironment)
        {
            GallImages_Service = service;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View(GallImages_Service.GetList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GalleriesImages_Model galleriesImages_Model)
        {
            string uniqueFileName = UploadedFile(galleriesImages_Model);
            GalleriesImage galleriesImage = new GalleriesImage
            {
                Id = galleriesImages_Model.Id,
                Name = galleriesImages_Model.Name,
                CreatedDate = galleriesImages_Model.CreatedDate,
                Image = uniqueFileName,
                ParentId = galleriesImages_Model.ParentId,
                Status = galleriesImages_Model.Status
            };
            if (ModelState.IsValid)
            {
                GallImages_Service.AddList(galleriesImage);
            }
           

            return RedirectToRoute("Admin", new { action = "Index", controller = "GallImages" });
        }
        public IActionResult Delete(int id)
        {
            GallImages_Service.Delete(id);
            return RedirectToRoute("Admin", new { action = "Index", controller = "GallImages" });
        }
        public IActionResult Update(int id)
        {
           
            return View(GallImages_Service.GetId(id));
            
        }
        [HttpPost]
        public IActionResult Update(GalleriesImage  galleriesImage, IFormFile Image)
        {
            string uniqueFileName = UploadedFile1(Image);
            if (Image != null)
            {
                galleriesImage.Image = uniqueFileName;
                GallImages_Service.Update(galleriesImage);
            }
            else
            {
                galleriesImage.Image = galleriesImage.Image;
                GallImages_Service.Update(galleriesImage);
            }
            
            return RedirectToRoute("Admin", new { action = "Index", controller = "GallImages" });
        }
        private string UploadedFile(GalleriesImages_Model model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Images/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedFile1(IFormFile model)
        {
            string uniqueFileName = null;

            if (model != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Images/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
