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
    public class GalleriesVideo_Service : IGallVideo_Service
    {
        private static ThanhAn_GroupContext db;
        public GalleriesVideo_Service(ThanhAn_GroupContext data)
        {
            db = data;
        }
        public GalleriesVideo AddList(GalleriesVideo baiviet)
        {
            db.GalleriesVideos.Add(baiviet);
            db.SaveChanges();
            return baiviet;

        }

        public bool Delete(int id)
        {
            bool check = false;
            try
            {
                db.GalleriesVideos.Remove(GetId(id));
                db.SaveChanges();
                check = true;
            }
            catch (Exception)
            {

                throw;
            }
            return check;
        }

        public GalleriesVideo GetId(int id)
        {
          return  db.GalleriesVideos.Find(id);

        }

        public List<GalleriesVideo> GetList()
        {
            return db.GalleriesVideos.ToList();
        }

        public GalleriesVideo Update(GalleriesVideo baiviet)
        {
            db.GalleriesVideos.Update(baiviet);
            db.SaveChanges();
            return baiviet;
        }
    }
}
