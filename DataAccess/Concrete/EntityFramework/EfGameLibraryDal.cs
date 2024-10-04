using Core.DataAccess.EfEntityRepository;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGameLibraryDal : EfEntityRepositoryBase<GameLibrary,MySqlContext>, IGameLibraryDal
    {
        public EfGameLibraryDal()
        {
            
        }
    }
}
