using Core.DataAccess.CrossTables;
using Core.DataAccess.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Relation
{
    public class LibraryGames : ICrossTable
    {
        public int GameLibraryId { get; set; }
        public int GameId { get; set; }

        public GameLibrary Library { get; set; }
        public Game Game { get; set; }
    }
}
