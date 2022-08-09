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
    public class LoginController : Controller
    {
        private static IAdministrator_Service administrator_Service;
        public LoginController(IAdministrator_Service admintrator_S)
        {
            administrator_Service = admintrator_S;
        }
       
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(Administrator administrator)
        {
            if (ModelState.IsValid)
            {
             var check =  administrator_Service.Authorize(administrator);
                if (check != null)
                {
                    HttpContext.Session.SetString("username", administrator.UserName);
                    return RedirectToRoute("Admin", new { action = "Index", controller = "TrangChu" });
                }
            }
            return View();
        }
       
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToRoute("Admin", new { action = "Index", controller = "TrangChu" });
        }
        public IActionResult Dang_Ky()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Dang_Ky(Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                administrator_Service.AddList(administrator);
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View();
            
        }

        public IActionResult Index()
        {

            return View(administrator_Service.GetList());
        }
        
        public IActionResult Update(int id)
        {
           
            return View(administrator_Service.GetId(id));
        }
        [HttpPost]
        public IActionResult Update(Administrator administrator)
        {
            administrator_Service.Update(administrator);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Login" });

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Administrator administrator)
        {
            administrator_Service.AddList(administrator);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Login" });
        }
        public IActionResult Delete(int id)
        {
            administrator_Service.Delete(id);
            return RedirectToRoute("Admin", new { action = "Index", controller = "Login" });
        }
    }
}
