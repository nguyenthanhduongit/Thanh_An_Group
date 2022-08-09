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
    public class SlideController : Controller
    {
        private static ISlide_Service slide_Service;
        private readonly IWebHostEnvironment hostEnvironment;

        public SlideController(ISlide_Service service, IWebHostEnvironment hostEnvironment)
        {
            slide_Service = service;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View(slide_Service.GetList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Empolee emploeess)
        {
            string uniqueFileName = UploadedFile(emploeess);
            Slide slide = new Slide
            {
                SlideId = emploeess.SlideId,
                SlideName = emploeess.SlideName,
                Images = uniqueFileName,
                DisplayOrder = emploeess.DisplayOrder,
                Status = emploeess.Status
            };

            if (ModelState.IsValid)
            {
                slide_Service.AddList(slide);
            }
            
            return RedirectToRoute("Admin", new { action = "Index", controller = "Slide" });
        }
        public IActionResult Delete(int id)
        {
            slide_Service.Delete(id);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Slide" });
        }
        public IActionResult Update(int id)
        {
          
            return View(slide_Service.GetId(id));
        }
        [HttpPost]
        public IActionResult Update(Slide slide, IFormFile Images)
        {
            string uniqueFileName = UploadedFile1(Images);
            if (Images != null)
            {
                slide.Images = uniqueFileName;
                slide_Service.Update(slide);
            }
            else
            {
                slide.Images = slide.Images;
                slide_Service.Update(slide);
            }
            return RedirectToRoute("Admin", new { action = "Index", controller = "Slide" });
            

           
        }
        private string UploadedFile(Empolee model)
        {
            string uniqueFileName = null;

            if (model.ImagesUploand != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Images/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagesUploand.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagesUploand.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
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
