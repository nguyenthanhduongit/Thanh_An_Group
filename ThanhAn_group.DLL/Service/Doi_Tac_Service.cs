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
    public class Doi_Tac_Service : IDoi_Tac_Service
    {
        private static ThanhAn_GroupContext db;
        public Doi_Tac_Service(ThanhAn_GroupContext data)
        {
            db = data;
        }
        public DoiTac AddList(DoiTac doiTac)
        {
            db.DoiTacs.Add(doiTac);
            db.SaveChanges();
            return doiTac;
        }

        public bool Delete(int id)
        {
            bool check = false;
            try
            {
                db.DoiTacs.Remove(GetId(id));
                db.SaveChanges();
                check = true;
            }
            catch (Exception)
            {

                throw;
            }
            return check;
        }

        public DoiTac GetId(int id)
        {
            return db.DoiTacs.Find(id);
        }

        public List<DoiTac> GetList()
        {
            return db.DoiTacs.ToList();
        }

        public DoiTac Update(DoiTac doiTac)
        {
            db.DoiTacs.Update(doiTac);
            db.SaveChanges();
            return doiTac;
        }
    }
}
