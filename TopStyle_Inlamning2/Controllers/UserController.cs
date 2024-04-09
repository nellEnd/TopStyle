using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyle_Inlamning2.Domain.DTO;

namespace TopStyle_Inlamning2.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/login")]
        public async Task <IActionResult> Login(UserLoginDTO user)
        {

        }
    }
}
