﻿using Core.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Requests.Game
{
    public class UpdateGameModel : IRequestModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int GamePrice { get; set; }
        public string GameDescription { get; set; }
        public string GameGenre { get; set; }

        public UpdateGameModel()
        {

        }

    }
}
