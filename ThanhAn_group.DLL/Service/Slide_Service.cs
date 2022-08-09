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
    public class Slide_Service : ISlide_Service
    {
        private static ThanhAn_GroupContext db;
        public Slide_Service(ThanhAn_GroupContext data)
        {
            db = data;
        }
        public Slide AddList(Slide slide)
        {
            db.Slides.Add(slide);
            db.SaveChanges();
            return slide;
                
        }

        public bool Delete(int id)
        {
            bool check = false;
            try
            {
                db.Slides.Remove(GetId(id));
                db.SaveChanges();
                check = true;
            }
            catch (Exception)
            {

                throw;
            }
            return check;
        }

        public Slide GetId(int id)
        {
            return db.Slides.Find(id);

        }

        public List<Slide> GetList()
        {
            return db.Slides.ToList();
        }

        public Slide Update(Slide baiviet)
        {
            db.Slides.Update(baiviet);
            db.SaveChanges();
            return baiviet;
        }
    }
}
