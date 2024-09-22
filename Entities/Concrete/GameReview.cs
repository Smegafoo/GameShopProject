using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GameReview : IEntity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Review { get; set; }
        public int ReviewPoint { get; set; }

    }
}
