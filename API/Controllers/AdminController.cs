using Business.Abstract;
using DataAccess.Abstract;
using Entities.Constants;
using Entities.DTO_s.Requests.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
           _adminService = adminService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAdmin(AddAdminModel model)
        {
            try
            {
               var result = await _adminService.AddAdmin(model);
                if(result.Success)
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

        public async Task <IActionResult> DeleteAdmin(int id)
        {
            try
            {
                var result = await _adminService.DeleteAdmin(id);
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

        public async Task<IActionResult> UpdateAdmin(UpdateAdminModel model)
        {
            try
            {
                var result = await _adminService.UpdateAdmin(model);
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

        public async Task<IActionResult> GetAllAdmin()
        {
            try
            {
                var result = await _adminService.GetAll();
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

        public async Task<IActionResult> GetByAdmınId(int id)
        {
            try
            {
                var result = await _adminService.GetById(id);
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
