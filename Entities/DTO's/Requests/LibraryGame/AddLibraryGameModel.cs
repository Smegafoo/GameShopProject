using Core.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Requests.LibraryGame
{
    public class AddLibraryGameModel : IAddModel
    {
        public int GameLibraryId { get; set; }
        public int GameId {  get; set; }

        public AddLibraryGameModel()
        {
            
        }
    }
}
