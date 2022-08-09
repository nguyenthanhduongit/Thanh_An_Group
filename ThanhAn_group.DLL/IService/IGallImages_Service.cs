using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhAn_Group.DAL.Models;

namespace ThanhAn_group.BLL.IService
{
   public interface IGallImages_Service
    {
        List<GalleriesImage> GetList();
        GalleriesImage AddList(GalleriesImage galleriesImage);
        bool Delete(int id);
        GalleriesImage GetId(int id);

        GalleriesImage Update(GalleriesImage galleriesImage);
    }
}
