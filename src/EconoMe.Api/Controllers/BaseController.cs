using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace EconoMe.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long GetLoggedInUserId()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            long.TryParse(id, out long userId);
            return userId;
        }
    }
}