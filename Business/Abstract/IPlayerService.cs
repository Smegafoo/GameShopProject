using Core.Utilies.Results;
using Entities.Concrete;
using Entities.DTO_s.Requests.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPlayerService
    {
      
        Task<IResult> AddPlayer(AddPlayerModel model);
        Task<IResult> UpdatePlayer(UpdatePlayerModel model);
        Task<IResult> DeletePlayer(int id);

        Task<IDataResult<List<Player>>> GetAll();
        Task<IDataResult<List<Player>>> GetById(int id);
      
    }
}
