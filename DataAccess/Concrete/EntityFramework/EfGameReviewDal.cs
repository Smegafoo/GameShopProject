using Core.DataAccess.EfEntityRepository;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGameReviewDal : EfEntityRepositoryBase<GameReview, MySqlContext>, IGamereviewDal
    {
        public async Task<List<GameReview>> GetAllByGameId(int id)
        {
            using (var context = new MySqlContext())
            {
                var reviews = await context.GameReviews.Where(p => p.GameId == id)
                    .Select(review => new GameReview
                    {
                        Id=review.Id,
                        GameId = review.GameId,
                        Review = review.Review,
                        ReviewPoint = review.ReviewPoint,
                    }).ToListAsync();

                return reviews;
            }

        }
    }
}
