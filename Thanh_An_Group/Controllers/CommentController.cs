using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Data;
using ThanhAn_Group.DAL.Models;


namespace Thanh_An_Group.Controllers
{
    public class CommentController : Controller
    {
        public static List<Slide> GetSlide()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<Slide> slide = DB.Slides.ToList();
                return slide;
            }
        }
        public static List<Baiviet> GetTinTuc()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<Baiviet> baiviets = DB.Baiviets.Where(a => a.Types == 2).ToList();
                return baiviets;
            }
        }

        public static List<Baiviet> GetBaochi()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<Baiviet> baiviets = DB.Baiviets.Where(a => a.Types == 1).ToList();
                return baiviets;
            }
        }
        public static List<Baiviet> Gethdxh()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<Baiviet> baiviets = DB.Baiviets.Where(a => a.Types == 3).ToList();
                return baiviets;
            }
        }
        public static List<DoiTac> GetDoiTac()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<DoiTac> doitac = DB.DoiTacs.ToList();
                return doitac;
            }
        }
        public JsonResult  GetBaochiPages(string category,int page)
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                int type;
                if(category == "newspapers")
                {
                    type = 1;
                }else if(category == "news")
                {
                    type = 2;
                }
                else
                {
                    type = 3;
                }
                
                List<Baiviet> baiviets = DB.Baiviets.Where(a => a.Types == type).Skip(page).Take(4).ToList();
                if(baiviets.Count > 0)
                {
                    return new JsonResult(new { 
                    StatusCode = 200,
                    msg = "OK",
                    baiviet = baiviets
                    });
                }
                return new JsonResult(new
                {
                    StatusCode = 400,
                    msg = "ERRORR",
                    baiviet = baiviets
                }); ;
            }
        }
    }
}
