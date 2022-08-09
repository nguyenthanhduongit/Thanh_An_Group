using Microsoft.AspNetCore.Http;
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
    public class Administrator_Service : IAdministrator_Service
    {
        private static ThanhAn_GroupContext db;
        public Administrator_Service(ThanhAn_GroupContext data)
        {
            db = data;
        }
        public Administrator AddList(Administrator administrator)
        {
            db.Administrators.Add(administrator);
            db.SaveChanges();
            return administrator;
        }

        public string Authorize(Administrator administrator)
        {
            var DataUser = db.Administrators.FirstOrDefault(x => x.UserName.Equals(administrator.UserName));
            if (administrator.UserName == DataUser.UserName && administrator.UserName == DataUser.Password)
            {
                return "Sucssess";
            }
            return "Ko trung tk";
        }

        public bool Delete(int id)
        {
            bool check = false;
            try
            {
                db.Administrators.Remove(GetId(id));
                db.SaveChanges();
                return check = true;
            }
            catch (Exception e)
            {

                throw;
            }
            return check;
        }

        public Administrator GetId(int id)
        {
            return db.Administrators.Find(id);
        }

        public List<Administrator> GetList()
        {
            return db.Administrators.ToList();
        }

        public Administrator Update(Administrator administrator)
        {
            db.Administrators.Update(administrator);
            db.SaveChanges();
            return administrator;
        }
    }
}
