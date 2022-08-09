using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanhAn_group.BLL.IService;
using ThanhAn_Group.DAL.Models;

namespace Thanh_An_Group.Controllers
{
    public class Bai_VietController : Controller
    {
        private static IBaiViet_Services baiViet_Services;
        public Bai_VietController(IBaiViet_Services service)
        {
            baiViet_Services = service;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Detail(int id)
        {
            var check = baiViet_Services.GetId(id);
            if (check == null )
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(check);
            }
        }
        public IActionResult Pages(int page = 1,int pagesize = 4)
        {
            var Data = baiViet_Services.GetList();
           
            int totalpages = (int)Math.Ceiling((double)Data.Count() / pagesize);
            return View(Data.Skip((page - 1) * pagesize).Take(pagesize));
        }
    }
}
