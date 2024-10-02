using Core.Utilies.Results;
using Entities.Concrete;
using Entities.DTO_s.Requests.GameReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameReviewService
    {
        Task<IResult> AddGameReview(AddGameReviewModel model);
        Task<IResult> DeleteGameReview(int id);
        Task<IResult> UpdateGameReview(UpdateGameReviewModel model);

        Task<IDataResult<List<GameReview>>> GetById(int id);
        Task<IDataResult<List<GameReview>>> GetAllByGameId(int id);
    }
}
