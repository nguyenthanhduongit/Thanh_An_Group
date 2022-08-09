using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thanh_An_Group.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrangChuController : Controller
    {
        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToRoute("Admin", new { action = "Login", controller = "Login" });
            }
            return View();
        }
        
    }
}
