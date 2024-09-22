using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Game: IEntity
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int GamePrice { get; set; }
        public string GameDescription { get; set; }
        public  string GameGenre { get; set; }
        
        List<GameLibrary> Libraries { get; set; }
    
    }
}
