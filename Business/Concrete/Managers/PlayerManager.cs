using Business.Abstract;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using Entities.DTO_s.Requests.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class PlayerManager : IPlayerService
    {
        private readonly IPlayerDal _playerDal;

        public PlayerManager(IPlayerDal playerDal)
        {
            _playerDal = playerDal;
            
        }

        //CUD Operations

        public async Task<IResult> AddPlayer(AddPlayerModel model)
        {
            try
            {
                Player player = new Player()
                {
                    PlayerName = model.PlayerName,
                    PlayerDescription = model.PlayerDescription,
                    GameLibraryId = model.GameLıbraryId,

                };
                await _playerDal.Add(player);
                return new SuccesResult(Messages.AddMessages.EXCEPTION_ADDEDPLAYER);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> DeletePlayer(int id)
        {
            try
            {
                var game = await _playerDal.Get(p=> p.Id == id);
                if(game != null)
                {
                    await _playerDal.Delete(game);
                    return new SuccesResult(Messages.DeleteMessages.EXCEPTION_PLAYERDELETED);
                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_PLAYERNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IResult> UpdatePlayer(UpdatePlayerModel model)
        {
            try
            {
                var playerId = model.Id;
                var playertoUpdate = await _playerDal.Get(p => p.Id == playerId);
                if (playertoUpdate != null)
                {
                    playertoUpdate.PlayerName = model.PlayerName;
                    playertoUpdate.PlayerDescription = model.PlayerDescription;
                    playertoUpdate.GameLibraryId = model.GameLıbraryId;
                    await _playerDal.Update(playertoUpdate);
                    return new SuccesResult(Messages.UpdateMessages.EXCEPTION_PLAYERUPDATED);

                }
                else
                {
                    return new ErrorResult(Messages.NotFound.EXCEPTION_PLAYERNOTFOUND);
                }

            }
            catch (Exception e )
            {

                throw e;
            }
        }

        //******************************************************

        //Reading Operations

        public async Task<IDataResult<List<Player>>> GetAll()
        {
            try
            {
                var players = await _playerDal.GetAll();
                if (players != null && players.Count > 0)
                {
                    return new SuccessDataResult<List<Player>>(players, Messages.ReadMessages.EXCEPTION_GETALLPLAYERS);

                }
                else
                {
                    return new ErrorDataResult<List<Player>>(Messages.ReadMessages.EXCEPTION_LISTEMPTY);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IDataResult<List<Player>>> GetById(int id)
        {
            try
            {
                var player = await _playerDal.Get(p => p.Id == id);
                if (player != null)
                {
                    return new SuccessDataResult<List<Player>>(new List<Player> { player }, Messages.ReadMessages.EXCEPTION_FOUNDBYIDPLAYER);
                }
                else
                {
                    return new ErrorDataResult<List<Player>>(Messages.NotFound.EXCEPTION_PLAYERNOTFOUND);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        
    }
}
