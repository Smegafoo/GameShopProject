using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string PlayerDescription { get; set; }


        public int GameLibraryId { get; set; }
        public GameLibrary Games { get; set; }

    }
}
