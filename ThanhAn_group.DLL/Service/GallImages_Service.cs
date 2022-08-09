using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhAn_group.BLL.IService;
using ThanhAn_Group.DAL.Data;
using ThanhAn_Group.DAL.Models;

namespace ThanhAn_group.BLL.Service
{
   public class GallImages_Service : IGallImages_Service
    {
        private static ThanhAn_GroupContext db;
        public GallImages_Service(ThanhAn_GroupContext data)
        {
            db = data;
        }

        public GalleriesImage AddList(GalleriesImage galleriesImage)
        {
            db.GalleriesImages.Add(galleriesImage);
            db.SaveChanges();
            return galleriesImage;
        }

        public bool Delete(int id)
        {
            bool check = false;
            try
            {
                db.GalleriesImages.Remove(GetId(id));
                db.SaveChanges();
                check = true;
            }
            catch (Exception)
            {

                throw;
            }
            return check;
        }

        public GalleriesImage GetId(int id)
        {
            return db.GalleriesImages.Find(id);
        }

        public List<GalleriesImage> GetList()
        {
            return db.GalleriesImages.ToList();
        }

        public GalleriesImage Update(GalleriesImage galleriesImage)
        {
            db.GalleriesImages.Update(galleriesImage);
            db.SaveChanges();
            return galleriesImage;
        }
        
    }
}
