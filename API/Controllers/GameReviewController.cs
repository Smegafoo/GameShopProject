using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTO_s.Requests.GameReview;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameReviewController : ControllerBase
    {
        IGameReviewService _gameReviewService;
        public GameReviewController(IGameReviewService gameReviewService)
        {
            _gameReviewService = gameReviewService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> ReviewAdd(AddGameReviewModel model)
        {
            try
            {
                var result = await _gameReviewService.AddGameReview(model);
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

                throw e;
            }
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _gameReviewService.DeleteGameReview(id);
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

                throw e;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateGameReviewModel updateGameReviewModel)
        {
            try
            {
                var result = await _gameReviewService.UpdateGameReview(updateGameReviewModel);
                if (result.Success) 
                { 
                return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message );
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [HttpGet("GetAllByGameId")]

        public async Task<IActionResult> GetAllByGameId(int id)
        {
            try
            {
                var result = await _gameReviewService.GetAllByGameId(id);
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

                throw e;
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var result =await _gameReviewService.GetById(id);
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

                throw e;
            }
        }
    }
}
