﻿using Core.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Requests.GameReview
{
    public class UpdateGameReviewModel : IUpdateModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Review { get; set; }
        public int ReviewPoint {  get; set; }

        public UpdateGameReviewModel()
        {
            
        }
    }
}
