using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Models;

namespace ThanhAn_group.BLL.IService
{
   public interface ISlide_Service
    {
        List<Slide> GetList();
        Slide AddList(Slide slide);
        bool Delete(int id);
        Slide GetId(int id);

        Slide Update(Slide slide);
    }
}
