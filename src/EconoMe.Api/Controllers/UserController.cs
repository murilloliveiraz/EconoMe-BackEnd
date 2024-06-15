using System.Security.Authentication;
using EconoMe.Api.Contracts.User;
using EconoMe.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController : ControllerBase
    {
       private readonly IUserService _userService;

       public UserController(IUserService userService)
       {
         _userService = userService;
       }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(UserRequestContract model)
        {
            try
            {
                return Created("", await _userService.Create(model, 0));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(UserLoginRequestContract model)
        {
            try
            {
                return Ok(await _userService.Authenticate(model));
            }
            catch(AuthenticationException ex)
            {
                return Unauthorized(new {statusCode = 401, message = ex.Message});
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _userService.Get(0));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                return Ok(await _userService.GetById(id, 0));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, UserRequestContract model)
        {
            try
            {
                return Ok(await _userService.Update(id, model, 0));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.Delete(id, 0);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}