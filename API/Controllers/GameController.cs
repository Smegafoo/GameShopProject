using Business.Abstract;
using Entities.Constants;
using Entities.DTO_s.Requests.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddGameModel model)
        {
            try
            {
                var result = await _gameService.AddGame(model);

                if (result.Success) 
                { 
                    return Ok(new
                    {
                        message = result.Message,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = result.Message,
                    });
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


        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result =await _gameService.DeleteGame(id);

                if (result.Success)
                {
                    return Ok(new
                    {
                        message = result.Message,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = result.Message,
                    });
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

        [HttpPut("Update")]

        public async Task<IActionResult> Update(UpdateGameModel model)
        {
            try
            {
                var result = await _gameService.Update(model);

                if (result.Success) { 
                
                return Ok(result.Message);
                }
                else
                {
                    return BadRequest(new
                    {
                        message = Messages.ServerMessages.EXCEPTION_ERROR
                    });
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

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _gameService.GetAll();
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

                return StatusCode (500,new
                {
                    message=Messages.ServerMessages.EXCEPTION_ERROR
                });
            }
        }

        [HttpGet ("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _gameService.GetById(id);
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

                return StatusCode(500,new 
                {
                    message= Messages.ServerMessages.EXCEPTION_ERROR
                });
            }

        }
    }
}
