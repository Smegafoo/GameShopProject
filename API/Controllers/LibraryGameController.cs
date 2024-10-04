using Business.Abstract;
using Entities.DTO_s.Requests.LibraryGame;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryGameController : ControllerBase
    {

        ILibraryGameService _libraryGameService;
        public LibraryGameController(ILibraryGameService libraryGameService)
        {
            _libraryGameService = libraryGameService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddLibraryGameModel model)
        {
            try
            {
                var result = await _libraryGameService.Add(model);
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

        public async Task<IActionResult> DeleteGameFromLibrary(int id1, int id2)
        {
            try
            {
                var result = await _libraryGameService.Delete(id1, id2);
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

        [HttpGet("GetAllGamesFromLibrary")]

        public async Task<IActionResult> GetAllGamesFromLibrary(int id)
        {
            try
            {
                var result = await _libraryGameService.GetAllPlayerGamesByLıbraryId(id);
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

        [HttpGet("GetAllGamesByLibraryId")]

        public async Task<IActionResult> GetAllGamesByLibraryId(int id)
        {
            try
            {
                var result = await _libraryGameService.GetAllGamesDetailsFromLibraies(id);

                if(result != null)
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
