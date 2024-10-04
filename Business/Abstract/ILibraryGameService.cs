using Core.Utilies.Results;
using Entities.DTO_s.Dto_s;
using Entities.DTO_s.Requests.LibraryGame;
using Entities.Relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILibraryGameService
    {
        Task<IResult> Add(AddLibraryGameModel model);
       
        Task<IResult> Delete(int id1,int id2);
        Task<IDataResult<List<LibraryGames>>> GetAllPlayerGamesByLıbraryId(int id);

        public Task<IDataResult<List<LibraryDto>>> GetAllGamesDetailsFromLibraies(int id);




    }
}
