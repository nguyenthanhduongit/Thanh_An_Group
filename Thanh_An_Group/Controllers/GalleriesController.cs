using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Data;
using ThanhAn_Group.DAL.Models;

namespace Thanh_An_Group.Controllers
{
    public class GalleriesController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public static List<GalleriesImage> GetGallImages()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<GalleriesImage> gallImages = DB.GalleriesImages.ToList();
                return gallImages;
            }
        }
        public static List<GalleriesVideo> GetGallVideo()
        {
            using (var DB = new ThanhAn_GroupContext())
            {
                List<GalleriesVideo> gallVideo = DB.GalleriesVideos.ToList();
                return gallVideo;
            }
        }
    }
}
