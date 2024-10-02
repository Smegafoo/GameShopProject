using Business.Abstract;
using Entities.DTO_s.Requests.GameLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameLibraryControlller : ControllerBase
    {
        IGameLibraryService _gameLibraryService;

        public GameLibraryControlller(IGameLibraryService gameLibraryService)
        {
            _gameLibraryService = gameLibraryService;
            
        }

        [HttpPost("Add")]

        public async Task<IActionResult> GameLibraryAdd(AddGameLibraryModel model)
        {
            try
            {
                var result=await _gameLibraryService.GameLibraryAdd(model);
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
        public async Task<IActionResult> GameLibraryDelete(int id)
        {
            try
            {
                var result =await _gameLibraryService.GameLibraryDelete(id);
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

        public async Task<IActionResult> GameLibraryUpdate(UpdateGameLibraryModel model)
        {
            try
            {
                var result = await _gameLibraryService.GameLibraryUpdate(model);
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

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAllLibraries()
        {
            try
            {
                var result = await _gameLibraryService.GetAll();
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

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _gameLibraryService.GetById(id);
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
