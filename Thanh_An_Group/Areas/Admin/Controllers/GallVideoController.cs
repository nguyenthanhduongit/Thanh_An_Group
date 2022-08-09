using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThanhAn_group.BLL.IService;
using ThanhAn_Group.DAL.Models;

namespace Thanh_An_Group.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GallVideoController : Controller
    {
        private static IGallVideo_Service gallVideo_Service;
        public GallVideoController(IGallVideo_Service service)
        {
            gallVideo_Service = service;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View(gallVideo_Service.GetList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GalleriesVideo galleriesVideo)
        {
            if (ModelState.IsValid)
            {
                gallVideo_Service.AddList(galleriesVideo);
            }
         
            return RedirectToRoute("Admin", new { action = "Index", controller = "GallVideo" });
        }
        public IActionResult Delete(int id)
        {
            gallVideo_Service.Delete(id);
            return RedirectToRoute("Admin", new { action = "Index", controller = "GallVideo" });
        }
        public IActionResult Update(int id)
        {
            return View(gallVideo_Service.GetId(id));
        }
        [HttpPost]
        public IActionResult Update(GalleriesVideo galleriesVideo)
        {
            gallVideo_Service.Update(galleriesVideo);

            return RedirectToRoute("Admin", new { action = "Index", controller = "GallVideo" });
        }
    }
}
