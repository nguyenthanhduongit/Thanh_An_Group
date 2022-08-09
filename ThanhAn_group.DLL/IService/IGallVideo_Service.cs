using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Models;

namespace ThanhAn_group.BLL.IService
{
   public interface IGallVideo_Service
    {
        List<GalleriesVideo> GetList();
        GalleriesVideo AddList(GalleriesVideo baiviet);
        bool Delete(int id);
        GalleriesVideo GetId(int id);

        GalleriesVideo Update(GalleriesVideo baiviet);
    }
}
