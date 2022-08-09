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
    public class Doi_TacController : Controller
    {
        private static IDoi_Tac_Service doi_Tac_Service;
        public Doi_TacController(IDoi_Tac_Service service)
        {
            doi_Tac_Service = service;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View(doi_Tac_Service.GetList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DoiTac doiTac)
        {
            if (ModelState.IsValid) {
                doi_Tac_Service.AddList(doiTac);
            }
                
            return RedirectToRoute("Admin", new { action = "Index", controller = "Doi_Tac" });
        }
        public IActionResult Delete(int id)
        {
            doi_Tac_Service.Delete(id);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Doi_Tac" });
        }
        public IActionResult Update(int id)
        {
            
            return View(doi_Tac_Service.GetId(id));
        }
        [HttpPost]
        public IActionResult Update(DoiTac doiTac)
        {
            doi_Tac_Service.Update(doiTac);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Doi_Tac" });
        }
    }
}
