using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Models;

namespace ThanhAn_group.BLL.IService
{
   public interface IDoi_Tac_Service
    {
        List<DoiTac> GetList();
        DoiTac AddList(DoiTac doiTac);
        bool Delete(int id);
        DoiTac GetId(int id);

        DoiTac Update(DoiTac doiTac);
    }
}
