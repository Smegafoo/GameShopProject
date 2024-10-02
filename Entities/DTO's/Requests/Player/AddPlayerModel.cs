using Core.Dto.Request;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Requests.Player
{
    public class AddPlayerModel :IAddModel
    {
        public string PlayerName { get; set; }
        public string PlayerDescription { get; set; }
        public int GameLıbraryId {  get; set; }
        
        public AddPlayerModel()
        {

        }
    }
}
