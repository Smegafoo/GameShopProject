using Core.Utilies.Results;
using Entities.Concrete;
using Entities.DTO_s.Requests.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        Task<IResult> AddAdmin(AddAdminModel model);
        Task<IResult> DeleteAdmin(int id);

        Task<IResult> UpdateAdmin(UpdateAdminModel model);
        Task<IDataResult<List<Admin>>> GetAll();
        Task<IDataResult<List<Admin>>> GetById(int id);
    }
}
