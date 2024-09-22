using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Relation
{
    public class LibraryGames
    {
        public int GameLibraryId { get; set; }
        public int GameId { get; set; }

        public GameLibrary Library { get; set; }
        public Game Game { get; set; }
    }
}
