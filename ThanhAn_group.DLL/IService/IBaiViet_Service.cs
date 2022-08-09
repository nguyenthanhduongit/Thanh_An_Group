using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThanhAn_Group.DAL.Models;

namespace ThanhAn_group.BLL.IService
{
    public interface IBaiViet_Services
    {
        List<Baiviet> GetList();
        Baiviet AddList(Baiviet baiviet);
        bool Delete(int id);
        Baiviet GetId(int id);

        Baiviet Update(Baiviet baiviet);
    }
}
