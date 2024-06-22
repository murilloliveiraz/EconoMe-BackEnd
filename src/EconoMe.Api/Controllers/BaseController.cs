using System.Security.Claims;
using EconoMe.Api.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long _userId;

        protected long GetLoggedInUserId()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            long.TryParse(id, out long userId);
            return userId;
        }

        protected ErrorContract ThrowBadRequest(Exception ex)
        {
            return new ErrorContract{
                StatusCode = 400,
                Title = "Bad Request",
                Description = ex.Message,
                Date = DateTime.Now,
            };
        }
        
        protected ErrorContract ThrowNotFound(Exception ex)
        {
            return new ErrorContract{
                StatusCode = 404,
                Title = "Not Found",
                Description = ex.Message,
                Date = DateTime.Now,
            };
        }
        
        protected ErrorContract ThrowUnauthorized(Exception ex)
        {
            return new ErrorContract{
                StatusCode = 401,
                Title = "Unauthorized",
                Description = ex.Message,
                Date = DateTime.Now,
            };
        }
    }
}