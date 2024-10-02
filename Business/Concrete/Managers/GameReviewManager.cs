using Business.Abstract;
using Core.Utilies.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Constants;
using Entities.DTO_s.Requests.GameReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class GameReviewManager : IGameReviewService
    {

        IGamereviewDal _gamereviewDal;
        public GameReviewManager(IGamereviewDal gamereviewDal)
        {
            _gamereviewDal = gamereviewDal;
        }

        //CUD Operations
        public async Task<IResult> AddGameReview(AddGameReviewModel model)
        {
            try
            {
                GameReview gameReview = new GameReview()
                {
                    GameId = model.GameId,
                    Review = model.Review,
                    ReviewPoint = model.ReviewPoint,
                };

                await _gamereviewDal.Add(gameReview);
                return new SuccesResult(Messages.AddMessages.EXCEPTION_ADDEDGAMEREVIEW);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> DeleteGameReview(int id)
        {
            try
            {
                var reviewId=await _gamereviewDal.Get(p=>p.Id==id);
                if (reviewId != null)
                {
                    await _gamereviewDal.Delete(reviewId);
                    return new SuccesResult(Messages.DeleteMessages.EXCEPTION_REVIEWDELETED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_REVIEWNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IResult> UpdateGameReview(UpdateGameReviewModel model)
        {
            try
            {
                var reviewId = model.Id;
                var reviewtoUpdate=await _gamereviewDal.Get(p=> p.Id==reviewId);
                if (reviewtoUpdate != null)
                {

                    reviewtoUpdate.GameId = model.GameId;
                    reviewtoUpdate.Review = model.Review;
                    reviewtoUpdate.ReviewPoint = model.ReviewPoint;
                    _gamereviewDal.Update(reviewtoUpdate);


                    return new SuccesResult(Messages.UpdateMessages.EXCEPTION_REVIEWUPDATED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_REVIEWNOTFOUND);
                }
                



            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //******************************************************************

        //Read Operations

        public async Task<IDataResult<List<GameReview>>> GetAllByGameId(int id)
        {
            try
            {
                var reviews=await _gamereviewDal.GetAllByGameId(id);

                return new SuccessDataResult<List<GameReview>>(reviews, Messages.ReadMessages.EXCEPTION_FOUNDBYGAMEIDREVIEW);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IDataResult<List<GameReview>>> GetById(int id)
        {
            try
            {
                var review=await _gamereviewDal.Get(p=> p.Id==id);
                if (review != null)
                {
                    return new SuccessDataResult<List<GameReview>>
                        (new List<GameReview> { review }, Messages.ReadMessages.EXCEPTION_FOUNDBIYIDREVIEW);
                }
                else
                {
                    return new ErrorDataResult<List<GameReview>>(Messages.NotFound.EXCEPTION_REVIEWNOTFOUND);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //**************************************************

        
    }
}
