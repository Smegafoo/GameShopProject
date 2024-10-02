using Business.Abstract;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.DTO_s.Requests.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class GameManager : IGameService
    {
        

        private readonly IGameDal _gameDal;

        public GameManager(IGameDal gameDal)
        {
            _gameDal = gameDal;
        }

        //CUD Oprations

        public async Task<IResult> AddGame(AddGameModel model)
        {
            try
            {
                Game game = new Game()
                {
                    GameName = model.GameName,
                    GameDescription = model.GameDescription,
                    GameGenre = model.GameGenre,
                    GamePrice = model.GamePrice,
                };

                await _gameDal.Add(game);

                return new SuccesResult(Messages.AddMessages.EXCEPTION_ADDEDGAME);
            }
            catch (Exception e)
            {
                //log, database, console
                throw e;
            }
        }

        public async Task<IResult> DeleteGame(int id)
        {
            try
            {
                var gameId = await _gameDal.Get(p => p.Id == id);
                if (gameId != null)
                {
                    await _gameDal.Delete(gameId);

                    return new SuccesResult(Messages.DeleteMessages.EXCEPTION_GAMEDELETED);
                }
                else 
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_GAMENOTFOUND);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> Update(UpdateGameModel model)
        {
            try
            {
                int gameID = model.Id;
                var gametoUpdate = await _gameDal.Get(p => p.Id == gameID);
                if (gametoUpdate != null)
                {
                    gametoUpdate.GameName = model.GameName;
                    gametoUpdate.GamePrice = model.GamePrice;
                    gametoUpdate.GameDescription = model.GameDescription;
                    gametoUpdate.GameGenre = model.GameGenre;
                    _gameDal.Update(gametoUpdate);
                    return new SuccesResult(Messages.UpdateMessages.EXCEPTION_GAMEUPDATED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_GAMENOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        //********************************************************

        //Read Operations

        public async Task<IDataResult<List<Game>>> GetAll()
        {
            var games=await _gameDal.GetAll();
            if(games!=null && games.Count > 0)
            {
                return new SuccessDataResult<List<Game>>(games,Messages.ReadMessages.EXCEPTION_GETALLGAMES);
            }
            else
            {
                return new ErrorDataResult<List<Game>>(Messages.ReadMessages.EXCEPTION_LISTEMPTY);
            }
        }

        public async Task<IDataResult<List<Game>>> GetById(int gameId)
        {
            var game= await _gameDal.Get(p=>p.Id==gameId);
            if (game != null)
            {
                return new SuccessDataResult<List<Game>>(new List<Game> {game},Messages.ReadMessages.EXCEPTION_FOUNDBYID);
            }
            else
            {
                return new ErrorDataResult<List<Game>>(Messages.NotFound.EXCEPTION_GAMENOTFOUND);
            }
        }

        //********************************************

        
    }
}
