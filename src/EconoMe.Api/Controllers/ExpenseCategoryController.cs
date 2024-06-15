using EconoMe.Api.Contracts.ExpenseCategory;
using EconoMe.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    [ApiController]
    [Route("transacoes")]
    public class ExpenseCategoryController : BaseController
    {
       private readonly IService<ExpenseCategoryRequestContract, ExpenseCategoryResponseContract, long> _ExpenseCategoryService;
       private long _userId;

       public ExpenseCategoryController(IService<ExpenseCategoryRequestContract, ExpenseCategoryResponseContract, long> ExpenseCategoryService)
       {
         _ExpenseCategoryService = ExpenseCategoryService;
       }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ExpenseCategoryRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Created("", await _ExpenseCategoryService.Create(model, _userId));
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
                return Ok(await _ExpenseCategoryService.Get(_userId));
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
                return Ok(await _ExpenseCategoryService.GetById(id, _userId));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, ExpenseCategoryRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Ok(await _ExpenseCategoryService.Update(id, model, _userId));
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
                await _ExpenseCategoryService.Delete(id, _userId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}