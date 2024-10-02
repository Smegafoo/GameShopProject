using Core.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Requests.GameLibrary
{
    public class AddGameLibraryModel : IAddModel
    {
        public int PlayerId {  get; set; }
        public string PlayerName { get; set; }
        public int GameNumber {  get; set; }

        public AddGameLibraryModel()
        {
            
        }
    }
}
