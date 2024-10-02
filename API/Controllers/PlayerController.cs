using Business.Abstract;
using Entities.Constants;
using Entities.DTO_s.Requests.Player;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> PlayerAdd(AddPlayerModel addPlayerModel)
        {
            try
            {
                var result = await _playerService.AddPlayer(addPlayerModel);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }

            }
            catch (Exception e)
            {

                return StatusCode(500, new
                {
                    message = Messages.ServerMessages.EXCEPTION_ERROR
                });
            }

        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> PlayerDeleted(int id)
        {
            try
            {
                var result = await _playerService.DeletePlayer(id);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }

            }
            catch (Exception e)
            {

                return StatusCode(500,new
                {
                    message=Messages.ServerMessages.EXCEPTION_ERROR
                });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerModel updatePlayerModel)
        {
            try
            {
                var result = await _playerService.UpdatePlayer(updatePlayerModel);
                    if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }

            }
            catch (Exception e)
            {

                return StatusCode(500,new
                {
                    message = Messages.ServerMessages.EXCEPTION_ERROR
                });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _playerService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception e)
            {

                throw e ;
            }
        }

        [HttpGet ("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _playerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
