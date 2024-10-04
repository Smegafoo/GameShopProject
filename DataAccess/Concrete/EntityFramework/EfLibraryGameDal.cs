using Core.DataAccess.EfEntityRepository;
using Core.DataAccess.Entities;
using DataAccess.Abstract;
using Entities.DTO_s.Dto_s;
using Entities.Relation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLibraryGameDal : EfEntityRepositoryBase<LibraryGames,MySqlContext> , ILibraryGameDal
    {
        public EfLibraryGameDal()
        {
            
        }

        public async Task<List<LibraryDto>> GetAllGamesDetailsFromLibraies(int id)
        {
            await using (var context = new MySqlContext())
            {
                var result = from p in context.LibraryGames
                             join j in context.Games on p.GameId equals j.Id
                             
                             where p.GameLibraryId == id
                             select new LibraryDto
                             {
                                 game = j,
                                 
                             };
                return  await result.ToListAsync();

            }

        }
    }
}
