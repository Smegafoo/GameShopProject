using Core.DataAccess;
using Core.DataAccess.Entities;
using Entities.DTO_s.Dto_s;
using Entities.Relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILibraryGameDal : IEntityRepository<LibraryGames>
    {
        public Task<List<LibraryDto>> GetAllGamesDetailsFromLibraies(int id);
    }
}
