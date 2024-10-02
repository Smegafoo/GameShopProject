using Business.Abstract;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.DTO_s.Requests.GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class GameLibraryManager : IGameLibraryService
    {
        IGameLibraryDal _gameLibraryDal;
        public GameLibraryManager(IGameLibraryDal gameLibraryDal)
        {
            _gameLibraryDal = gameLibraryDal;
        }


        //CUD Operations

        public async Task<IResult> GameLibraryAdd(AddGameLibraryModel model)
        {
            try
            {
                GameLibrary gameLibrary = new GameLibrary()
                {
                    PlayerID = model.PlayerId,
                    PlayerName = model.PlayerName,
                    GameNumber = model.GameNumber,
                };

                await _gameLibraryDal.Add(gameLibrary);
                return new SuccesResult(Messages.AddMessages.EXCEPTION_ADDEDGAMELIBRARY);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> GameLibraryDelete(int id)
        {
            try
            { 
                var gameLibrarytoDelete = await _gameLibraryDal.Get(p=> p.Id == id);
                if(gameLibrarytoDelete != null)
                {
                    await _gameLibraryDal.Delete(gameLibrarytoDelete);
                    return new SuccesResult(Messages.DeleteMessages.EXCEPTION_LIBRARYDELETED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_LIBRARYNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> GameLibraryUpdate(UpdateGameLibraryModel model)
        {
            try
            {

                var gameLibrary=await _gameLibraryDal.Get(p=>p.Id == model.Id);
                if(gameLibrary != null)
                {
                    gameLibrary.PlayerID = model.PlayerId;
                    gameLibrary.PlayerName = model.PlayerName;  
                    gameLibrary.GameNumber = model.GameNumber;

                    await _gameLibraryDal.Update(gameLibrary);
                    return new SuccesResult(Messages.UpdateMessages.EXCEPTION_LIBRARYUPDATED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_LIBRARYNOTFOUND);
                }
                

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //**************************************************************

        //Read Operations

        public async Task<IDataResult<List<GameLibrary>>> GetAll()
        {
            try
            {
                var gameLibraries= await _gameLibraryDal.GetAll();

                if(gameLibraries != null && gameLibraries.Count > 0)
                {
                    return new SuccessDataResult<List<GameLibrary>>(gameLibraries,Messages.ReadMessages.EXCEPTION_GETALLLIBRARIES);
                }
                else
                {
                    return new ErrorDataResult<List<GameLibrary>>(Messages.ReadMessages.EXCEPTION_LISTEMPTY);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IDataResult<List<GameLibrary>>> GetById(int id)
        {
            var library = await _gameLibraryDal.Get(p=> p.Id == id);
            if(library != null)
            {
                return new SuccessDataResult<List<GameLibrary>>(new List<GameLibrary>() { library},Messages.ReadMessages.EXCEPTION_FOUNDBYIDLIBRARY);
            }
            else
            {
                return new ErrorDataResult<List<GameLibrary>>(Messages.NotFound.EXCEPTION_LIBRARYNOTFOUND);
            }
        }

        //**************************************************
    }
}
