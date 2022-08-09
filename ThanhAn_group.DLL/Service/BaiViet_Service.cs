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
    public class BaiViet_Service : IBaiViet_Services
    {
        private static ThanhAn_GroupContext db;
        public BaiViet_Service(ThanhAn_GroupContext data)
        {
            db = data;
        }
        public Baiviet AddList(Baiviet baiviet)
        {
            db.Baiviets.Add(baiviet);
            db.SaveChanges();
            return baiviet;
        }

        public bool Delete(int id)
        {
            bool check = false;
            try
            {
                db.Baiviets.Remove(GetId(id));
                db.SaveChanges();
                check = true;
            }
            catch (Exception)
            {

                throw;
            }
            return check;
        }

        public Baiviet GetId(int id)
        {
            return db.Baiviets.Find(id);
        }

        public List<Baiviet> GetList()
        {
            return db.Baiviets.ToList();
        }

        public Baiviet Update(Baiviet baiviet)
        {
            db.Baiviets.Update(baiviet);
            db.SaveChanges();
            return baiviet;
        }
    }
}
