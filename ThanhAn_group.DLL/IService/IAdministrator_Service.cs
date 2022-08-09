using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Models;


namespace ThanhAn_group.BLL.IService
{
  public  interface IAdministrator_Service
    {
        List<Administrator> GetList();
        string Authorize(Administrator administrator);
        Administrator GetId(int id);
        bool Delete(int id);
        Administrator Update(Administrator administrator);
        Administrator AddList(Administrator administrator);
    }
}
