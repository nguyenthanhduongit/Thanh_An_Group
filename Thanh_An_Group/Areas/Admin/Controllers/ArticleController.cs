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
    public class ArticleController : Controller
    {
        private static IBaiViet_Services baiviet_Services;
        private readonly IWebHostEnvironment hostEnvironment;

        public ArticleController(IBaiViet_Services service, IWebHostEnvironment hostEnvironment)
        {
            baiviet_Services = service;
            this.hostEnvironment = hostEnvironment;
        }
       
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View(baiviet_Services.GetList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Baiviet_Model model)
        {
            string uniqueFileName = UploadedFile(model);
            Baiviet baiviet = new Baiviet
            {
                PkbaivietId = model.PkbaivietId,
                ShortContent = model.ShortContent,
                Contents = model.Contents,
                CreateDate = model.CreateDate,
                Images = uniqueFileName,
                Status = model.Status,
                Title = model.Title,
                Types = model.Types
            };
            if (ModelState.IsValid)
            {
                baiviet_Services.AddList(baiviet);
                
            }
            return RedirectToRoute("Admin", new { action = "Index", controller = "Article" });
        }
        public IActionResult Delete(int id)
        {
            baiviet_Services.Delete(id);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Article" });
        }
        public IActionResult Update(int id)
        {
            
            return View(baiviet_Services.GetId(id));
        }
        [HttpPost]
        public IActionResult Update(Baiviet baiviet,IFormFile Images)
        {
            string uniqueFileName = UploadedFile1(Images);
            if (Images != null)
            {
                baiviet.Images = uniqueFileName;
                baiviet_Services.Update(baiviet);
            }
            else
            {
                baiviet.Images = baiviet.Images;
                baiviet_Services.Update(baiviet);
            }  
            return RedirectToRoute("Admin", new { action = "Index", controller = "Article" });
        }
        public IActionResult Detail(int id)
        {
            

            return View(baiviet_Services.GetId(id));
        }
        private string UploadedFile(Baiviet_Model model)
        {
            string uniqueFileName = null;

            if (model.Images != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Images/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Images.CopyTo(fileStream);
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
