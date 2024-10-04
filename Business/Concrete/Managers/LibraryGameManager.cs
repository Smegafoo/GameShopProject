using Business.Abstract;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Constants;
using Entities.DTO_s.Dto_s;
using Entities.DTO_s.Requests.LibraryGame;
using Entities.Relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class LibraryGameManager : ILibraryGameService
    {
        ILibraryGameDal _libraryGameDal;
        public LibraryGameManager(ILibraryGameDal libraryGameDal)
        {
            _libraryGameDal=libraryGameDal;
        }

        //CUD Operations
        public async Task<IResult> Add(AddLibraryGameModel model)
        {
            try
            {
                LibraryGames libraryGames =new LibraryGames()
                {
                    GameLibraryId = model.GameLibraryId,
                    GameId = model.GameId,
                };
                await _libraryGameDal.Add(libraryGames);

                return new SuccesResult(Messages.AddMessages.EXCEPTION_ADDEDLIBRARYGAME);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> Delete(int id1 ,int id2)
        {
            try
            {
                var libraryGame = await _libraryGameDal.Get(p => p.GameLibraryId == id1 && p.GameId == id2);
                if (libraryGame !=null)
                {
                    await _libraryGameDal.Delete(libraryGame);
                    return new SuccesResult(Messages.DeleteMessages.EXCEPTION_LIBRARYGAMEDELETED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_LIBRARYGAMENOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        




        //*******************************

        //Reading Operations

        public async Task<IDataResult<List<LibraryGames>>> GetAllPlayerGamesByLıbraryId(int id)
        {
            try
            {
                var Library=await _libraryGameDal.GetAll(p=> p.GameLibraryId==id);
                if(Library!=null && Library.Count > 0)
                {
                    return new SuccessDataResult<List<LibraryGames>>(Library,Messages.ReadMessages.EXCEPTION_FOUNDBYIDLIBRARY);
                }
                else
                {
                    return new SuccessDataResult<List<LibraryGames>>(Messages.NotFound.EXCEPTION_LIBRARYNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IDataResult<List<LibraryDto>>> GetAllGamesDetailsFromLibraies(int id)
        {
            try
            {
                var result = await _libraryGameDal.GetAllGamesDetailsFromLibraies(id);
                return new SuccessDataResult<List<LibraryDto>>(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }



        //****************************************************


    }
}
