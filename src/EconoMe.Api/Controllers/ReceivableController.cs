using EconoMe.Api.Contracts;
using EconoMe.Api.Contracts.Receivable;
using EconoMe.Api.Domain.Services.Interfaces;
using EconoMe.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    [ApiController]
    [Route("recebimentos")]
    public class ReceivableController : BaseController
    {
       private readonly IService<ReceivableRequestContract, ReceivableResponseContract, long> _receivableService;

       public ReceivableController(IService<ReceivableRequestContract, ReceivableResponseContract, long> ReceivableService)
       {
         _receivableService = ReceivableService;
       }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ReceivableRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Created("", await _receivableService.Create(model, _userId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ThrowNotFound(ex));
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ThrowBadRequest(ex));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Ok(await _receivableService.Get(_userId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ThrowNotFound(ex));
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
                _userId = GetLoggedInUserId();
                return Ok(await _receivableService.GetById(id, _userId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ThrowNotFound(ex));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, ReceivableRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Ok(await _receivableService.Update(id, model, _userId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ThrowNotFound(ex));
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ThrowBadRequest(ex));
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
                _userId = GetLoggedInUserId();
                await _receivableService.Delete(id, _userId);
                return NoContent();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ThrowNotFound(ex));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}