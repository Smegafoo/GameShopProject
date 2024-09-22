using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  class GameLibrary : IEntity
    {
        public int Id { get; set; }
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int GameNumber { get; set; }
        public List<Game> Games { get; set; }
    }
}
