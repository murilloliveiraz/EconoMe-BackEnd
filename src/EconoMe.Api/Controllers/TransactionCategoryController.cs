using EconoMe.Api.Contracts.TransactionCategory;
using EconoMe.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    [ApiController]
    [Route("transacoes")]
    public class TransactionCategoryController : BaseController
    {
       private readonly IService<TransactionCategoryRequestContract, TransactionCategoryResponseContract, long> _TransactionCategoryService;
       private long _userId;

       public TransactionCategoryController(IService<TransactionCategoryRequestContract, TransactionCategoryResponseContract, long> TransactionCategoryService)
       {
         _TransactionCategoryService = TransactionCategoryService;
       }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(TransactionCategoryRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Created("", await _TransactionCategoryService.Create(model, _userId));
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
                return Ok(await _TransactionCategoryService.Get(_userId));
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
                return Ok(await _TransactionCategoryService.GetById(id, _userId));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, TransactionCategoryRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Ok(await _TransactionCategoryService.Update(id, model, _userId));
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
                await _TransactionCategoryService.Delete(id, _userId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}