using Core.Utilies.Results;
using Entities.Concrete;
using Entities.DTO_s.Requests.GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameLibraryService
    {
        Task<IResult> GameLibraryAdd(AddGameLibraryModel model);
        Task<IResult> GameLibraryDelete(int id);
        Task<IResult> GameLibraryUpdate(UpdateGameLibraryModel model);

        Task<IDataResult<List<GameLibrary>>> GetAll();
        Task<IDataResult<List<GameLibrary>>> GetById(int id);
    }
}
