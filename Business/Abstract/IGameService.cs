using Core.Utilies.Results;
using Entities.Concrete;
using Entities.DTO_s.Requests.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameService
    {
        Task<IResult> AddGame(AddGameModel model);
        Task<IResult> Update(UpdateGameModel model);

        Task<IResult> DeleteGame(int id);

        Task<IDataResult <List<Game>>>GetAll();
        Task<IDataResult<List<Game>>> GetById(int gameId);
    }
}
