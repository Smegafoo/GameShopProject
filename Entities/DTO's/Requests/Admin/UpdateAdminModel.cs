using Core.Dto.Request;
using Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Requests.Admin
{
    public class UpdateAdminModel : IUpdateModel
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public Authority AdminLevel { get; set; }

        public UpdateAdminModel()
        {
            
        }
    }
}
