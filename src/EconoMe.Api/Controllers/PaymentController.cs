using EconoMe.Api.Contracts.Payment;
using EconoMe.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    [ApiController]
    [Route("pagamentos")]
    public class PaymentController : BaseController
    {
       private readonly IService<PaymentRequestContract, PaymentResponseContract, long> _paymentService;
       private long _userId;

       public PaymentController(IService<PaymentRequestContract, PaymentResponseContract, long> paymentService)
       {
         _paymentService = paymentService;
       }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PaymentRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Created("", await _paymentService.Create(model, _userId));
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
                return Ok(await _paymentService.Get(_userId));
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
                return Ok(await _paymentService.GetById(id, _userId));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, PaymentRequestContract model)
        {
            try
            {
                _userId = GetLoggedInUserId();
                return Ok(await _paymentService.Update(id, model, _userId));
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
                await _paymentService.Delete(id, _userId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}